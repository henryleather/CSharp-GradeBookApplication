using System;
using System.Collections.Generic;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var listOfAverageGrades = Students.Select(e => e.AverageGrade).ToList();
            listOfAverageGrades.Sort();

            var twentyPercentDouble = Math.Ceiling(listOfAverageGrades.Count * 0.20);
            var twentyPercent = Convert.ToInt32(twentyPercentDouble);
            var totalGrades = listOfAverageGrades.Count;

            if (averageGrade > listOfAverageGrades[totalGrades - 1 - twentyPercent])
            {
                return 'A';
            }
            else if (averageGrade > listOfAverageGrades[totalGrades - 1 - 2 * twentyPercent])
            {
                return 'B';
            }
            else if (averageGrade > listOfAverageGrades[totalGrades - 1 - 3 * twentyPercent])
            {
                return 'C';
            }
            else if (averageGrade > listOfAverageGrades[totalGrades - 1 - 4 * twentyPercent])
            {
                return 'D';
            }
            return 'F';
        }
    }
}

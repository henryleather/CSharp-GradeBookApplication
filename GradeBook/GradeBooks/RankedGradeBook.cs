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

            var listOfAverageGrades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            var twentyPercentDouble = Math.Ceiling(listOfAverageGrades.Count * 0.20);
            var twentyPercent = Convert.ToInt32(twentyPercentDouble);

            if (averageGrade > listOfAverageGrades[twentyPercent - 1])
            {
                return 'A';
            }
            else if (averageGrade > listOfAverageGrades[2 * twentyPercent - 1])
            {
                return 'B';
            }
            else if (averageGrade > listOfAverageGrades[3 * twentyPercent - 1])
            {
                return 'C';
            }
            else if (averageGrade > listOfAverageGrades[4 * twentyPercent - 1])
            {
                return 'D';
            }
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return; 
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
         
            base.CalculateStudentStatistics(name);
        }
    }
}

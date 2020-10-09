using System;
using System.Collections.Generic;
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

            var listOfAverageGrades = new List<double>();

            foreach (Student student in Students)
            {
                listOfAverageGrades.Add(student.AverageGrade);
            }
            listOfAverageGrades.Sort();

            var twentyPercentDouble = listOfAverageGrades.Count * 0.20;
            var twentyPercent = Convert.ToInt32(twentyPercentDouble);
            int index = 0;

            for (int x = 0; x < listOfAverageGrades.Count; x++)
            {
                if (averageGrade < listOfAverageGrades[x])
                {
                    index = x+1;
                    break;
                }
                if (x == listOfAverageGrades.Count)
                {
                    index = x+1;
                }
            }

            int marker = listOfAverageGrades.Count;
            int count = 0;
            while (index < marker)
            {
                count += 1;
                marker -= twentyPercent;
            }

            if (count == 0)
            {
                return 'A';
            }
            else if (count == 1)
            {
                return 'B';
            }
            else if (count == 2)
            {
                return 'C';
            }
            else if (count == 3)
            {
                return 'D';
            }
            return 'F';
        }
    }
}

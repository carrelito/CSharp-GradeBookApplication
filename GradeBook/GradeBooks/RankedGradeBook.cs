using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count< 5)
            {
                throw new InvalidOperationException("Ranked - grading requires a minimum of 5 students to work");
            }
            if (GetGradeA(averageGrade))
                return 'A';
            else if (GetGradeB(averageGrade))
                return 'B';
            else if (GetGradeC(averageGrade))
                return 'C';
            else if (GetGradeD(averageGrade))
                return 'D';
            else
            return 'F';
        }

        private bool GetGradeA( double averageGrade)
        {
            return GetGrade(averageGrade, 20);
        }

        private bool GetGradeB(double averageGrade)
        {
            return GetGrade(averageGrade, 40);
        }
        private bool GetGradeC(double averageGrade)
        {
            return GetGrade(averageGrade, 60);
        }
        private bool GetGradeD(double averageGrade)
        {
            return GetGrade(averageGrade, 80);
        }

        private bool GetGrade(double averageGrade, int pourcentage)
        {
            int index = 0;
            index = (int)Math.Ceiling((double)(pourcentage * Students.Count / 100));
            var grades = Students.OrderByDescending(x => x.AverageGrade).Select(x => x.AverageGrade).ToList();
            if (averageGrade >= grades[index-1])
                return true;
            else
                return false;
        }

    }
}

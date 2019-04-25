

using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count <5)
            {
                throw new InvalidOperationException("Ranked GradeBooks atleast needs data of 5 students");

            }
            var threshhold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(avge => avge.AverageGrade).Select(av => av.AverageGrade).ToList();
            if (grades[threshhold - 1] <= averageGrade)
                return 'A';
            else if (grades[threshhold * 2 - 1] <= averageGrade)
                return 'B';
            else if (grades[threshhold * 3 - 1] <= averageGrade)
                return 'C';
            else if (grades[threshhold * 4 - 1] <= averageGrade)
                return 'D';
            else return 'F';






            
        }
    }
}

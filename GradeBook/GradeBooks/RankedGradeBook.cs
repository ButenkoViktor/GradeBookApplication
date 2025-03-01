using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Students with less than 5 ");
            }
            var sortedGrades = Students.Select(s => s.AverageGrade).ToList();

            sortedGrades.Sort();

            sortedGrades.Reverse();

            int studentsInputGrade = (int)Math.Ceiling(Students.Count * 0.2);

            int rank = sortedGrades.IndexOf(averageGrade);

            if (rank < studentsInputGrade)
                return 'A';
            else if (rank < studentsInputGrade * 2)
                return 'B';
            else if (rank < studentsInputGrade * 3)
                return 'C';
            else if (rank < studentsInputGrade * 4)
                return 'D';
            else
                return 'F';

        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.\" to the Console.");
                return;
            }
            else if (Students.Count >= 5)
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            else if (Students.Count >= 5)
            {
                base.CalculateStudentStatistics(name);
            }


        }
    }
}

using System;
using TreeCollection.TestModels.Enums;

namespace TreeCollection.TestModels.Models
{
    public class ExamResult : IComparable<ExamResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exams Exam { get; set; }
        public Score Score { get; set; }
        public DateTime Date { get; set; }

        public ExamResult(int id, string name, Exams exam, Score score, DateTime date)
        {
            Id = id;
            Name = name;
            Exam = exam;
            Score = score;
            Date = date;
        }

        public int CompareTo(ExamResult? other)
        {
            if (other == null)
            {
                return 1; // null is greater than non-null
            }

            // Compare based on student name first
            int result = string.Compare(Name, other.Name, StringComparison.Ordinal);
            if (result != 0)
            {
                return result;
            }

            // If names are the same, compare based on date
            result = DateTime.Compare(Date, other.Date);
            if (result != 0)
            {
                return result;
            }

            // If names and dates are the same, compare based on ID
            return Id.CompareTo(other.Id);
        }
    }
}

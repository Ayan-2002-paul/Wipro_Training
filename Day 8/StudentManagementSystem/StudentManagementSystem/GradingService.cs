using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class GradingService
    {
        public decimal CalculateTotal(List<decimal> marks)
        {
            return marks != null ? marks.Sum() : 0;
        }

        public decimal CalculateAverage(List<decimal> marks)
        {
            if (marks == null || !marks.Any()) return 0;
            return marks.Average();
        }

        public string DetermineGrade(decimal average)
        {
            if (average >= 90) return "A";
            if (average >= 80) return "B";
            if (average >= 70) return "C";
            if (average >= 60) return "D";
            return "F";
        }
    }
}

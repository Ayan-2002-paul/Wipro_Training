using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementSystem;
using System;
using System.Collections.Generic;

namespace StudentManagementSystemTest
{
    [TestClass]
    public class GradingServiceTests
    {
        private GradingService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new GradingService();
        }

        [TestMethod]
        public void CalculateTotal_WithValidMarks_ReturnsCorrectSum()
        {
            var marks = new List<decimal> { 80, 90, 70 };

            var result = _service.CalculateTotal(marks);

            Assert.AreEqual(240, result, "The total sum of marks is incorrect.");
        }

        [TestMethod]
        public void CalculateAverage_WithValidMarks_ReturnsCorrectAverage()
        {
            var marks = new List<decimal> { 100, 50 };

            var result = _service.CalculateAverage(marks);

            Assert.AreEqual(75, result, "The average calculation is incorrect.");
        }

        [TestMethod]
        [DataRow(95, "A")]
        [DataRow(82, "B")]
        [DataRow(70, "C")]
        [DataRow(45, "F")]
        public void DetermineGrade_FlowTest(double average, string expectedGrade)
        {
            var result = _service.DetermineGrade((decimal)average);

            Assert.AreEqual(expectedGrade, result, $"Grade mismatch for average {average}");
        }
    }
}

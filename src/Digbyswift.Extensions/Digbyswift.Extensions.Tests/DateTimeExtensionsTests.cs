using System;
using Digbyswift.Core.Models;
using NUnit.Framework;

namespace Digbyswift.Extensions.Test
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        
        #region GetDaysUntil

        // [SetCulture("en-GB")]
        // [TestCase(1)]
        // [TestCase(7)]
        // [TestCase(100)]
        // [TestCase(1000)]
        // public void GetDaysUntil_ReturnsPositiveNumberOfDays_WhenTargetDateIsInFuture(int daysInTheFuture)
        // {
        //     // Arrange
        //     var targetDate = _todayUtc.AddDays(daysInTheFuture);
        //
        //     // Act
        //     var result = targetDate.GetDaysUntil();
        //
        //     // Assert
        //     Assert.That(result, Is.Positive);
        //     Assert.That(result, Is.EqualTo(daysInTheFuture));
        // }
        //
        // [SetCulture("en-GB")]
        // [TestCase(0, 0, 0)]
        // [TestCase(0, 0, 1)]
        // [TestCase(23, 59, 59)]
        // public void GetDaysUntil_ReturnsZeroDays_WhenTargetDateIsTheSame(int hours, int seconds, int minutes)
        // {
        //     // Arrange
        //     var workingTime = new TimeSpan(hours, minutes, seconds);
        //     var targetDate = _todayUtc.Add(workingTime);
        //
        //     // Act
        //     var result = targetDate.GetDaysUntil();
        //
        //     // Assert
        //     Assert.That(result, Is.Zero);
        // }
        //
        // [SetCulture("en-GB")]
        // [TestCase(1)]
        // [TestCase(7)]
        // [TestCase(100)]
        // public void GetDaysUntil_ReturnsNegativeNumberOfDays_WhenTargetDateIsInPast(int daysInThePast)
        // {
        //     // Arrange
        //     var targetDate = _todayUtc.Subtract(TimeSpan.FromDays(daysInThePast));
        //
        //     // Act
        //     var result = targetDate.GetDaysUntil();
        //
        //     // Assert
        //     Assert.That(result, Is.Negative);
        //     Assert.That(result, Is.EqualTo(daysInThePast * -1));
        // }

        #endregion
        
        #region GetAge
        
        [SetCulture("en-GB")]
        [TestCase(2021, 11, 30, 0)]
        [TestCase(2020, 11, 1, 1)]
        [TestCase(2020, 1, 1, 1)]
        [TestCase(1976, 9, 9, 45)]
        public void GetAge_ReturnsCorrectNumberOfYears_WhenDobMonthIsBeforeTodaysMonth(int year, int month, int day, int expectedAge)
        {
            // Arrange
            var dob = new DateTime(year, month, day);
            var today = new DateTime(2021, 12, 31);
            SystemTime.Freeze(today);

            // Act
            var result = dob.GetAge();

            // Assert
            Assert.That(result, Is.EqualTo(expectedAge));
        }

        [SetCulture("en-GB")]
        [TestCase(2021, 11, 30, 0)]
        [TestCase(2020, 11, 1, 1)]
        [TestCase(2020, 1, 1, 1)]
        [TestCase(1976, 9, 9, 45)]
        public void GetAge_ReturnsCorrectNumberOfYears_WhenDobMonthIsAfterTodaysMonth(int year, int month, int day, int expectedAge)
        {
            // Arrange
            var dob = new DateTime(year, month, day);
            var today = new DateTime(2022, 1, 1);
            SystemTime.Freeze(today);

            // Act
            var result = dob.GetAge();

            // Assert
            Assert.That(result, Is.EqualTo(expectedAge));
        }

        [SetCulture("en-GB")]
        [Test]
        public void GetAge_ReturnsZero_WhenDobIsToday()
        {
            // Arrange
            var dob = new DateTime(2022, 1, 1);
            var today = new DateTime(2022, 1, 1);
            SystemTime.Freeze(today);

            // Act
            var result = dob.GetAge();

            // Assert
            Assert.That(result, Is.Zero);
        }

        [SetCulture("en-GB")]
        [TestCase(2022, 6, 1)]
        [TestCase(2022, 1, 1)]
        [TestCase(2022, 9, 9)]
        public void GetAge_ReturnsZero_WhenDobIsLessThanAYearBeforeToday(int year, int month, int day)
        {
            // Arrange
            var dob = new DateTime(2022, 1, 1);
            var today = new DateTime(2022, 1, 1);
            SystemTime.Freeze(today);

            // Act
            var result = dob.GetAge();

            // Assert
            Assert.That(result, Is.Zero);
        }

        [SetCulture("en-GB")]
        [TestCase(2022, 6, 1, -1)]
        [TestCase(2023, 1, 1, -1)]
        [TestCase(2066, 5, 30, -44)]
        [TestCase(2066, 9, 9, -45)]
        public void GetAge_ReturnsNegativeYears_WhenDobIsOverAYearAfterToday(int year, int month, int day, int expectedAge)
        {
            // Arrange
            var dob = new DateTime(year, month, day);
            var today = new DateTime(2021, 6, 1);
            SystemTime.Freeze(today);

            // Act
            var result = dob.GetAge();

            // Assert
            Assert.That(result, Is.EqualTo(expectedAge));
        }

        [SetCulture("en-GB")]
        [TestCase(2021, 6, 2)]
        [TestCase(2022, 1, 1)]
        [TestCase(2022, 5, 30)]
        public void GetAge_ReturnsZero_WhenDobIsLessThanAYearAfterToday(int year, int month, int day)
        {
            // Arrange
            var dob = new DateTime(year, month, day);
            var today = new DateTime(2021, 6, 1);
            SystemTime.Freeze(today);

            // Act
            var result = dob.GetAge();

            // Assert
            Assert.That(result, Is.Zero);
        }

        #endregion
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using program.Infrastructure;

namespace program.Tests.Infrastructure
{
    [TestClass]
    public class DateLogicTests
    {
        private readonly DateLogic dateLogicTest = new DateLogic();

        [TestMethod]
        public void DateValidator_given_valid_date_should_succeed()
        {
            //Arrange
            var dateToValid = "01.01.2017";
            DateTime exceptedDateTime = new DateTime(2017, 1, 1);

            //Act
            var validatedDate = dateLogicTest.DateValidator(dateToValid);

            //Assert
            Assert.AreEqual(exceptedDateTime, validatedDate);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DateValidator_given_invalid_date_should_throw_an_exception()
        {
            //Arrange
            var dateToValid = "41.02.2010";

            //Act
            try
            {
                dateLogicTest.DateValidator(dateToValid);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid date, please retry", e.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DateRange_given_incorrect_range_shoud_throw_an_exception()
        {
            //Arrange
            DateTime date1 = new DateTime(2017, 1, 5);
            DateTime date2 = new DateTime(2017, 1, 1);

            try
            {
                dateLogicTest.DateRange(date1, date2);
            }
            catch (Exception e)
            {
                Assert.AreEqual("There is no range between dates.", e.Message);
                throw;
            }
        }

        [TestMethod]
        public void DateRange_given_dates_from_same_years_and_months()
        {
            //Arrange
            DateTime date1 = new DateTime(2017, 1, 1);
            DateTime date2 = new DateTime(2017, 1, 5);

            //Act
            var dateRange = dateLogicTest.DateRange(date1, date2);

            //Assert
            Assert.AreEqual("01 - 05.01.2017", dateRange);
        }

        [TestMethod]
        public void DateRange_given_dates_from_same_years_and_different_months()
        {
            //Arrange
            DateTime date1 = new DateTime(2017, 1, 1);
            DateTime date2 = new DateTime(2017, 2, 5);

            //Act
            var dateRange = dateLogicTest.DateRange(date1, date2);

            //Assert
            Assert.AreEqual("01.01 - 05.02.2017", dateRange);
        }

        [TestMethod]
        public void DateRange_given_dates_from_different_years_and_different_months()
        {
            //Arrange
            DateTime date1 = new DateTime(2016, 1, 1);
            DateTime date2 = new DateTime(2017, 2, 5);

            //Act
            var dateRange = dateLogicTest.DateRange(date1, date2);

            //Assert
            Assert.AreEqual("01.01.2016 - 05.02.2017", dateRange);
        }
    }
}
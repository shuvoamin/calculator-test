using ApplicationCore.Enums;
using ApplicationCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.ApplicationCore.Models
{
    [TestClass]
    public class AppCoreFactoryTest
    {
        [TestMethod]
        public void CanGetCalculationResultObj()
        {
            // Arrange
            double inputResult = 1;

            // Act
            var result = AppCoreFactory.CreateCalculatinoResult(inputResult);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Result, inputResult);
        }

        [TestMethod]
        public void CanGetCalculationLoggingObj()
        {
            // Arrange
            string message = "This is a test message for logging obj";
            double leftInput = 0.5;
            double rightInput = 0.5;
            int logicCode = 1;
            double result = 0.25;
            DateTime timeStamp = DateTime.Now;

            // Act
            var actualCalcresult = AppCoreFactory.GetCalculationLoggingObj(
                message,
                leftInput,
                rightInput,
                logicCode,
                result,
                timeStamp
            );

            // Assert
            Assert.IsNotNull(actualCalcresult);
            Assert.AreEqual(message, actualCalcresult.Message);
            Assert.AreEqual(leftInput, actualCalcresult.LeftInput);
            Assert.AreEqual(rightInput, actualCalcresult.RightInput);
            Assert.AreEqual(logicCode, actualCalcresult.LogicId);
            Assert.AreEqual(result, actualCalcresult.Result);
            Assert.AreEqual(timeStamp, actualCalcresult.TimeStamp);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CanGetCalculationLogicExceptionForInvalidParam_DefaultEnum()
        {
            // Arrange
            var inputLogic = (ProbabilityCalculationLogic)0;

            // Act
            var result = AppCoreFactory.CreateCalculationLogic(inputLogic);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CanGetCalculationLogicExceptionForInvalidParam_OutOfRange()
        {
            // Arrange
            var inputLogic = (ProbabilityCalculationLogic)3;

            // Act
            var result = AppCoreFactory.CreateCalculationLogic(inputLogic);

            // Assert
        }

        [TestMethod]
        public void CanGetCombineCalculationLogic()
        {
            // Arrange
            var calculationLogic = ProbabilityCalculationLogic.CombineWith;

            // Act
            var result = AppCoreFactory.CreateCalculationLogic(calculationLogic);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.GetType() == typeof(CombineWithProbabilityLogic));
        }

        [TestMethod]
        public void CanGetEitherCalculationLogic()
        {
            // Arrange
            var calculationLogic = ProbabilityCalculationLogic.Either;

            // Act
            var result = AppCoreFactory.CreateCalculationLogic(calculationLogic);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.GetType() == typeof(EitherProbabilityLogic));
        }
    }
}

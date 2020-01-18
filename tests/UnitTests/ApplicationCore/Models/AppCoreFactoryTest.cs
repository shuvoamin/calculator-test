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

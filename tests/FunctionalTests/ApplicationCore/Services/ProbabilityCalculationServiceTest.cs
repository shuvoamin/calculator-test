﻿using ApplicationCore.Enums;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace FunctionalTests.ApplicationCore.Services
{
    [TestClass]
    public class ProbabilityCalculationServiceTest
    {
        private readonly IProbabilityCalculationService _probabilityCalculationService;
        private readonly Mock<IAppLogger<IProbabilityCalculationService>> _loggerMock;

        public ProbabilityCalculationServiceTest()
        {
            _loggerMock = new Mock<IAppLogger<IProbabilityCalculationService>>();

            _probabilityCalculationService = new ProbabilityCalculationService(_loggerMock.Object);
        }

        [TestMethod]
        public void ShouldReturnValidResultForCombineLogic_ManualCheck_Value1()
        {
            // Arrange
            double left = 1;
            double right = 1;
            var logic = ProbabilityCalculationLogic.CombineWith;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
            Assert.IsTrue(result.Result == 1);
        }

        [TestMethod]
        public void ShouldReturnValidResultForEitherLogic_ManualCheck_Value1()
        {
            // Arrange
            double left = 1;
            double right = 1;
            var logic = ProbabilityCalculationLogic.Either;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
            Assert.IsTrue(result.Result == 1);
        }

        [TestMethod]
        public void ShouldReturnValidResultForEitherLogic_ManualCheck_ValueZeroPointFive()
        {
            // Arrange
            double left = 0.5;
            double right = 0.5;
            var logic = ProbabilityCalculationLogic.Either;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
            Assert.IsTrue(result.Result == 0.75);
        }

        [TestMethod]
        public void ShouldReturnValidResultForCombineLogic_ManualCheck_ValueZeroPointFive()
        {
            // Arrange
            double left = 0.5;
            double right = 0.5;
            var logic = ProbabilityCalculationLogic.CombineWith;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
            Assert.IsTrue(result.Result == 0.25);
        }

        [TestMethod]
        public void ShouldReturnAResultForValidInputs()
        {
            // Arrange
            double left = 1;
            double right = 2;
            var logic = ProbabilityCalculationLogic.CombineWith;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
            Assert.IsTrue(result.Result != 0);
        }

        [TestMethod]
        public void ShouldReturnLoggingObjectForSuccessfullCalculation()
        {
            // Arrange
            double left = 0.5;
            double right = 0.5;
            var logic = ProbabilityCalculationLogic.CombineWith;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
            Assert.IsNotNull(result.LoggingObject);
        }

        [TestMethod]
        public void ValidateLoggingObjectForSuccessfullCalculation_CombineWithLogic()
        {
            // Arrange
            double left = 0.5;
            double right = 0.5;
            var logic = ProbabilityCalculationLogic.CombineWith;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
            Assert.IsNotNull(result.LoggingObject);
            Assert.IsNotNull(result.LoggingObject.Message);
            Assert.AreEqual(left, result.LoggingObject.LeftInput);
            Assert.AreEqual(right, result.LoggingObject.RightInput);
            Assert.AreEqual((int)logic, result.LoggingObject.LogicId);
            Assert.AreEqual(result.LoggingObject.Result, 0.25);
            Assert.IsTrue(result.LoggingObject.TimeStamp != default(DateTime));
        }

        [TestMethod]
        public void ValidateLoggingMechanismForSuccessfullCalculation_CombineWithLogic()
        {
            // Arrange
            double left = 0.5;
            double right = 0.5;
            var logic = ProbabilityCalculationLogic.CombineWith;
            string testingLogMessage = string.Empty;
            _loggerMock.Setup(l => l.LogInformation(It.IsAny<string>(), It.IsAny<object[]>()));

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
            Assert.IsNotNull(result.LoggingObject);
            Assert.IsNotNull(result.LoggingObject.Message);
            Assert.AreEqual(left, result.LoggingObject.LeftInput);
            Assert.AreEqual(right, result.LoggingObject.RightInput);
            Assert.AreEqual((int)logic, result.LoggingObject.LogicId);
            Assert.AreEqual(result.LoggingObject.Result, 0.25);
            Assert.IsTrue(result.LoggingObject.TimeStamp != default(DateTime));

            // check logging occuring at least once
            _loggerMock.Verify(r => r.LogInformation(It.IsAny<string>(), It.IsAny<object[]>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void ValidateLoggingMechanismForSuccessfullCalculation_EitherLogic()
        {
            // Arrange
            double left = 0.5;
            double right = 0.5;
            var logic = ProbabilityCalculationLogic.Either;
            string testingLogMessage = string.Empty;
            _loggerMock.Setup(l => l.LogInformation(It.IsAny<string>(), It.IsAny<object[]>()));

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
            Assert.IsNotNull(result.LoggingObject);
            Assert.IsNotNull(result.LoggingObject.Message);
            Assert.AreEqual(left, result.LoggingObject.LeftInput);
            Assert.AreEqual(right, result.LoggingObject.RightInput);
            Assert.AreEqual((int)logic, result.LoggingObject.LogicId);
            Assert.AreEqual(result.LoggingObject.Result, 0.75);
            Assert.IsTrue(result.LoggingObject.TimeStamp != default(DateTime));

            // check logging occuring at least once
            _loggerMock.Verify(r => r.LogInformation(It.IsAny<string>(), It.IsAny<object[]>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void ValidateLoggingObjectForSuccessfullCalculation_EitherLogic()
        {
            // Arrange
            double left = 0.5;
            double right = 0.5;
            var logic = ProbabilityCalculationLogic.Either;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
            Assert.IsNotNull(result.LoggingObject);
            Assert.IsNotNull(result.LoggingObject.Message);
            Assert.AreEqual(left, result.LoggingObject.LeftInput);
            Assert.AreEqual(right, result.LoggingObject.RightInput);
            Assert.AreEqual((int)logic, result.LoggingObject.LogicId);
            Assert.AreEqual(result.LoggingObject.Result, 0.75);
            Assert.IsTrue(result.LoggingObject.TimeStamp != default(DateTime));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionForLeftInvalidInput()
        {
            // Arrange
            double left = 0.1;
            double right = 1;
            var logic = ProbabilityCalculationLogic.CombineWith;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionForRightInvalidInput()
        {
            // Arrange
            double left = 0;
            double right = 1.1;
            var logic = ProbabilityCalculationLogic.CombineWith;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionForBothInvalidInput()
        {
            // Arrange
            double left = 1.1;
            double right = 10.1;
            var logic = ProbabilityCalculationLogic.CombineWith;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionForInvalidLogicInput()
        {
            // Arrange
            double left = 1;
            double right = 2;
            var logic = (ProbabilityCalculationLogic)0;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionForAllInvalidInputs()
        {
            // Arrange
            double left = -0.1;
            double right = 1.1;
            var logic = (ProbabilityCalculationLogic)0;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionForZeroAsInputValues_WithCombineLogic()
        {
            // Arrange
            double left = 0;
            double right = 0;
            var logic = (ProbabilityCalculationLogic)1;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionForZeroAsInputValues_WithEitherLogic()
        {
            // Arrange
            double left = 0;
            double right = 0;
            var logic = (ProbabilityCalculationLogic)2;

            // Act
            var result = _probabilityCalculationService.GetCalculationResult(left, right, logic);

            // Assert
        }
    }
}

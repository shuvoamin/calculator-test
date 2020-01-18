using ApplicationCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.ApplicationCore.Models
{
    [TestClass]
    public class EitherProbabilityLogicTest
    {
        [TestMethod]
        public void CangetCorrectProbabilityCalculationResult_Value1()
        {
            // Act
            double left = 1;
            double right = 1;
            var combineLogicObj = new EitherProbabilityLogic();

            // Arrange
            var result = combineLogicObj.GetCalculationResult(left, right);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void CangetCorrectProbabilityCalculationResult_Value2()
        {
            // Act
            double left = 0.5;
            double right = 2;
            var combineLogicObj = new EitherProbabilityLogic();

            // Arrange
            var result = combineLogicObj.GetCalculationResult(left, right);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 1.5);
        }
    }
}

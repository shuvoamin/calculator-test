using ApplicationCore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.ApplicationCore.Models
{
    [TestClass]
    public class CombineWithProbabilityLogicTest
    {
        [TestMethod]
        public void CanGetCorrectProbabilityCalculationResult_Value1()
        {
            // Arrange
            double left = 1;
            double right = 1;
            var combineLogicObj = new CombineWithProbabilityLogic();

            // Act
            var result = combineLogicObj.GetCalculationResult(left, right);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void CanGetCorrectProbabilityCalculationResult_Value2()
        {
            // Arrange
            double left = 10;
            double right = 5;
            var combineLogicObj = new CombineWithProbabilityLogic();

            // Act
            var result = combineLogicObj.GetCalculationResult(left, right);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 50);
        }
    }
}

using ApplicationCore.Interfaces;

namespace ApplicationCore.Models
{
    public class CombineWithProbabilityLogic : IProbabilityLogic
    {
        // P(A) * P(B)
        public double GetCalculationResult(double leftInput, double rightInput)
        {
            return leftInput * rightInput;
        }
    }
}

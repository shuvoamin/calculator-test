using ApplicationCore.Interfaces;

namespace ApplicationCore.Models
{
    public class EitherProbabilityLogic : IProbabilityLogic
    {
        // (P(A) + P(B)) - (P(A) * P(B))
        public double GetCalculationResult(double leftInput, double rightInput)
        {
            return ((leftInput + rightInput) - (leftInput * rightInput));
        }
    }
}

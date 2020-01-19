using ApplicationCore.Enums;

namespace ApplicationCore.Interfaces
{
    public interface IProbabilityCalculationService
    {
        ICalculationResult GetCalculationResult(
            double leftInput,
            double rightInput,
            int logicCode
        );
    }
}

using ApplicationCore.Models;

namespace ApplicationCore.Interfaces
{
    public interface ICalculationResult
    {
        double Result { get; set; }
        ICalculationLogging CalculationLogging { get; set; }
    }
}

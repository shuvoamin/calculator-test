using ApplicationCore.Interfaces;

namespace ApplicationCore.Models
{
    public class CalculationResult : ICalculationResult
    {
        public double Result { get; set; }
        public ICalculationLogging CalculationLogging { get; set; }
    }
}

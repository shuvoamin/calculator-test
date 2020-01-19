using ApplicationCore.Interfaces;

namespace ApplicationCore.Models
{
    public class CalculationResult : ICalculationResult
    {
        public double Result { get; set; }
        public ICalculationLoggingObject LoggingObject { get; set; }
    }
}

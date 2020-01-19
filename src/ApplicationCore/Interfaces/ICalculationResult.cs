using ApplicationCore.Models;

namespace ApplicationCore.Interfaces
{
    public interface ICalculationResult
    {
        double Result { get; set; }
        ICalculationLoggingObject LoggingObject { get; set; }
    }
}

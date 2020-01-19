using System;

namespace ApplicationCore.Interfaces
{
    public interface ICalculationLogging
    {
        string Message { get; set; }
        double LeftInput { get; set; }
        double RightInput { get; set; }
        int LogicId { get; set; }
        double Result { get; set; }
        DateTime TimeStamp { get; set; }
    }
}

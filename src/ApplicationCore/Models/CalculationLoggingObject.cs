using ApplicationCore.Interfaces;
using System;

namespace ApplicationCore.Models
{
    public class CalculationLoggingObject : ICalculationLoggingObject
    {
        public string Message { get; set; }
        public double LeftInput { get; set; }
        public double RightInput { get; set; }
        public int LogicId { get; set; }
        public double Result { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

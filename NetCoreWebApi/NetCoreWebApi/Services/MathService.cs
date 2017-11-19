using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Services
{
    public class MathService : IMathService
    {
        private readonly ICalcuator _calcuator;
        public MathService(ICalcuator calcuator)
        {
            _calcuator = calcuator;
        }

        public string Add(float x, float y)
        {
            return string.Format("{0:f2}", _calcuator.Add(x, y));
        }

        public string Substract(float x, float y)
        {
            return string.Format("{0:f2}", _calcuator.Subtract(x, y));
        }

        public string Multiply(float x, float y)
        {
            return string.Format("{0:f2}", _calcuator.Multiply(x, y));
        }

        public string Divide(float x, float y)
        {
            return string.Format("{0:f2}", _calcuator.Divide(x, y));
        }
    }
}

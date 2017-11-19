using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Services
{
    public class Calcuator : ICalcuator
    {
        public float Add(float x, float y)
        {
            return x + y;
        }

        public float Subtract(float x, float y)
        {
            return x - y;
        }

        public float Multiply(float x, float y)
        {
            return x * y;
        }

        public float Divide( float x, float y)
        {
            return x / y;
        }
    }
}

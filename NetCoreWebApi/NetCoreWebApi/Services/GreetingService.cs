using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Services
{
    public class GreetingService : IGreetingService
    {
        public string SayHelloTo(string who)
        {
            return $"Hello {who}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestedStockValue.Computation
{
    internal interface IVestedStockValueCalculator
    {
        Task<Dictionary<int, Calculator>> GetVestedAmount(Input input);
    }
}

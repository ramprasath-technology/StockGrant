using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestedStockValue.Inputs
{
    internal interface IInputProcessor
    {
        void GetUserInput(Input input);
    }
}

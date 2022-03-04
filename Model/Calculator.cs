using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Calculator
    {
        public decimal StockPrice { get; set; }
        public decimal GrantAmount { get; set; }
        public decimal GrantedStockCount { get; set; }
        public decimal VestedValue { get; set; }
        public decimal VestedStockCount { get; set; }
    }
}

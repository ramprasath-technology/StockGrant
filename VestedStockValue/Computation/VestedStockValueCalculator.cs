using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestedStockValue.Computation
{
    internal class VestedStockValueCalculator : IVestedStockValueCalculator
    {
        public VestedStockValueCalculator()
        {

        }

        public async Task<decimal> GetVestedAmount(Input input)
        {
            var yearComputationMap = new Dictionary<int, Calculator>(); 
            InitializeComputation(input, yearComputationMap);
            var stockPriceTask = Task.Factory.StartNew(() =>
            {
                ComputeStockPriceForEachYear(input, yearComputationMap);
            });
            var stockGrantTask = Task.Factory.StartNew(() =>
            {
                ComputeGrantForEachYear(input, yearComputationMap);
            });

            await stockPriceTask;
            await stockGrantTask;

            return 0m;
        }

        private void InitializeComputation(Input input,
            Dictionary<int, Calculator> yearComputationMap)
        {
            for (var startYear = input.BeginningYear.Year; startYear <= input.EndingYear.Year; startYear++)
            {
                yearComputationMap[startYear] = new Calculator();
            }
        }

        private void ComputeStockPriceForEachYear(Input input,
            Dictionary<int, Calculator> yearComputationMap)
        {
            var beginningYear = input.BeginningYear.Year;
            var endingYear = input.EndingYear.Year;
            var initialStockPrice = input.InitialStockPrice;
            var percentageChange = input.ExpectedAnnualizedPriceChange;
            var expectedPrice = initialStockPrice;
            yearComputationMap[beginningYear].StockPrice = initialStockPrice;

            for (var year = beginningYear + 1; year <= endingYear; year++)
            {
                expectedPrice = expectedPrice + (expectedPrice * percentageChange / 100);
                yearComputationMap[year].StockPrice = expectedPrice;
            }
        }

        private void ComputeGrantForEachYear(Input input,
            Dictionary<int, Calculator> yearComputationMap)
        {
            var beginningYear = input.BeginningYear.Year;
            var endingYear = input.EndingYear.Year;
            var initialGrantAmount = input.InitialGrantAmount;
            var percentageChange = input.ExpectedAnnualGrantChange;
            var expectedGrantAmount = initialGrantAmount;
            yearComputationMap[beginningYear].GrantAmount = initialGrantAmount;

            for (var year = beginningYear + 1; year <= endingYear; year++)
            {
                expectedGrantAmount = expectedGrantAmount + (expectedGrantAmount * percentageChange / 100);
                yearComputationMap[year].GrantAmount = expectedGrantAmount;
            }
        }
    }
}

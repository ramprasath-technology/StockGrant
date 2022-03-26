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

        public async Task<Dictionary<int, Calculator>> GetVestedAmount(Input input)
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

            ComputeStockCountAtGrantTime(input, yearComputationMap);
            ComputeVestingShareCount(input, yearComputationMap);
            ComputeVestingAmount(input, yearComputationMap);

            return yearComputationMap;
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

            for (var year = beginningYear; year <= endingYear; year++)
            {
                expectedGrantAmount = expectedGrantAmount + (expectedGrantAmount * percentageChange / 100);
                yearComputationMap[year].GrantAmount = expectedGrantAmount;
            }
        }

        private void ComputeStockCountAtGrantTime(Input input,
            Dictionary<int, Calculator> yearComputationMap)
        {
            foreach (var entry in yearComputationMap)
            {
                entry.Value.GrantedStockCount = entry.Value.GrantAmount / entry.Value.StockPrice;
            }
        }

        private void ComputeVestingShareCount(Input input,
            Dictionary<int, Calculator> yearComputationMap)
        {
            foreach (var entry in yearComputationMap)
            {
                var grantYear = entry.Key;
                var calculator = entry.Value;
                var vestingBeginYear = grantYear + 1;
                var vestingEndYear = Math.Min(vestingBeginYear + input.VestingPeriod - 1, input.EndingYear.Year);
                var vestingAmountPerYear = calculator.GrantedStockCount / input.VestingPeriod;
                for (var year = vestingBeginYear; year <= vestingEndYear; year++)
                {
                    yearComputationMap[year].VestedStockCount += vestingAmountPerYear;
                }
            }
        }

        private void ComputeVestingAmount(Input input,
            Dictionary<int, Calculator> yearComputationMap)
        {
            foreach (var entry in yearComputationMap)
            {
                var calculator = entry.Value;
                calculator.VestedValue = calculator.VestedStockCount * calculator.StockPrice;
            }
        }
    }
}

using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        private readonly ITradeDataProvider origProvider;

        public AdjustTradeDataProvider(ITradeDataProvider origProvider)
        {
            this.origProvider = origProvider;
        }

        public async Task<IEnumerable<string>> GetTradeData()
        {
            IEnumerable<string> lines = await origProvider.GetTradeData();

            List<string> result = new List<string>();

            foreach(var line in lines)
            {
                result.Add(line.Replace("GBP", "EUR"));
            }

            return result;
        }
    }
}

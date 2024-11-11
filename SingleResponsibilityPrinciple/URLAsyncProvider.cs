using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class URLAsyncProvider : ITradeDataProvider
    {
        private readonly ITradeDataProvider baseProvider;

        public URLAsyncProvider(ITradeDataProvider baseProvider)
        {
            this.baseProvider = baseProvider;
        }

        public async Task<IEnumerable<string>> GetTradeData()
        {
            //var task = Task.Run(() => baseProvider.GetTradeData());

            //return task.Result;

            return await baseProvider.GetTradeData();
        }
    }
}

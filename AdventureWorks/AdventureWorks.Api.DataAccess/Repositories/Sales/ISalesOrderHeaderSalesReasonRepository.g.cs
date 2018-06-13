using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesOrderHeaderSalesReasonRepository
        {
                Task<SalesOrderHeaderSalesReason> Create(SalesOrderHeaderSalesReason item);

                Task Update(SalesOrderHeaderSalesReason item);

                Task Delete(int salesOrderID);

                Task<SalesOrderHeaderSalesReason> Get(int salesOrderID);

                Task<List<SalesOrderHeaderSalesReason>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>166edf2619a64cc3dc23adc1d684545b</Hash>
</Codenesium>*/
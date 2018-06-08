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

                Task<List<SalesOrderHeaderSalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>da9c042e6de941a6702b94cf95f4e31c</Hash>
</Codenesium>*/
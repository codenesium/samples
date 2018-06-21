using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesOrderHeaderSalesReasonRepository
        {
                Task<SalesOrderHeaderSalesReason> Create(SalesOrderHeaderSalesReason item);

                Task Update(SalesOrderHeaderSalesReason item);

                Task Delete(int salesOrderID);

                Task<SalesOrderHeaderSalesReason> Get(int salesOrderID);

                Task<List<SalesOrderHeaderSalesReason>> All(int limit = int.MaxValue, int offset = 0);

                Task<SalesOrderHeader> GetSalesOrderHeader(int salesOrderID);

                Task<SalesReason> GetSalesReason(int salesReasonID);
        }
}

/*<Codenesium>
    <Hash>4f8a959ccc25ab4f4a1759f2bc0e3105</Hash>
</Codenesium>*/
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

                Task<List<SalesOrderHeaderSalesReason>> All(int limit = int.MaxValue, int offset = 0);

                Task<SalesOrderHeader> GetSalesOrderHeader(int salesOrderID);
                Task<SalesReason> GetSalesReason(int salesReasonID);
        }
}

/*<Codenesium>
    <Hash>085d5d73f6082191ab91910c677c5313</Hash>
</Codenesium>*/
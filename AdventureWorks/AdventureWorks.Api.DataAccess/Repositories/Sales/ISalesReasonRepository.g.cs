using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesReasonRepository
        {
                Task<SalesReason> Create(SalesReason item);

                Task Update(SalesReason item);

                Task Delete(int salesReasonID);

                Task<SalesReason> Get(int salesReasonID);

                Task<List<SalesReason>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<SalesOrderHeaderSalesReason>> SalesOrderHeaderSalesReasons(int salesReasonID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>df7e0d7e4b0165b6995a298819c0466d</Hash>
</Codenesium>*/
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesReasonRepository
        {
                Task<SalesReason> Create(SalesReason item);

                Task Update(SalesReason item);

                Task Delete(int salesReasonID);

                Task<SalesReason> Get(int salesReasonID);

                Task<List<SalesReason>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<SalesOrderHeaderSalesReason>> SalesOrderHeaderSalesReasons(int salesReasonID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9a28a7b60f7c431824a0e1efe0a1690c</Hash>
</Codenesium>*/
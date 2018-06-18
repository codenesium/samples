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

                Task<List<SalesReason>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<SalesOrderHeaderSalesReason>> SalesOrderHeaderSalesReasons(int salesReasonID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7c02895ab78c9b0cad029f4c4624029a</Hash>
</Codenesium>*/
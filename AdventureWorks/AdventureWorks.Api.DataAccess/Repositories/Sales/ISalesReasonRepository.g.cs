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

                Task<List<SalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>e6d8da57b5a9050b298481ec374f912e</Hash>
</Codenesium>*/
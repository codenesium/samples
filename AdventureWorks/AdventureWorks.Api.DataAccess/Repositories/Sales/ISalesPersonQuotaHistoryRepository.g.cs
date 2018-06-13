using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesPersonQuotaHistoryRepository
        {
                Task<SalesPersonQuotaHistory> Create(SalesPersonQuotaHistory item);

                Task Update(SalesPersonQuotaHistory item);

                Task Delete(int businessEntityID);

                Task<SalesPersonQuotaHistory> Get(int businessEntityID);

                Task<List<SalesPersonQuotaHistory>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>90efb482b2f924889a500bb73f921c9d</Hash>
</Codenesium>*/
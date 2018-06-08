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

                Task<List<SalesPersonQuotaHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>b1fce2ce06ade325a03ad67ea6ccea9a</Hash>
</Codenesium>*/
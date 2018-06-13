using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesTerritoryHistoryRepository
        {
                Task<SalesTerritoryHistory> Create(SalesTerritoryHistory item);

                Task Update(SalesTerritoryHistory item);

                Task Delete(int businessEntityID);

                Task<SalesTerritoryHistory> Get(int businessEntityID);

                Task<List<SalesTerritoryHistory>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>fac7f0bd8bcf7ed62b673ea6f7d9eb78</Hash>
</Codenesium>*/
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

                Task<List<SalesTerritoryHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>21acbf77251f28db59875faea07d7121</Hash>
</Codenesium>*/
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ISalesTerritoryRepository
        {
                Task<SalesTerritory> Create(SalesTerritory item);

                Task Update(SalesTerritory item);

                Task Delete(int territoryID);

                Task<SalesTerritory> Get(int territoryID);

                Task<List<SalesTerritory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<SalesTerritory> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>2ba88e6f8e91a9153c97bb0300a68886</Hash>
</Codenesium>*/
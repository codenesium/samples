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
    <Hash>ba341857a8c82a3d4b319b0315686175</Hash>
</Codenesium>*/
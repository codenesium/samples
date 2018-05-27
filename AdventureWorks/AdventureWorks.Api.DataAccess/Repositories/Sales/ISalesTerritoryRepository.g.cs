using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTerritoryRepository
	{
		Task<DTOSalesTerritory> Create(DTOSalesTerritory dto);

		Task Update(int territoryID,
		            DTOSalesTerritory dto);

		Task Delete(int territoryID);

		Task<DTOSalesTerritory> Get(int territoryID);

		Task<List<DTOSalesTerritory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOSalesTerritory> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>041f07001f6ade166f4f8595e404466f</Hash>
</Codenesium>*/
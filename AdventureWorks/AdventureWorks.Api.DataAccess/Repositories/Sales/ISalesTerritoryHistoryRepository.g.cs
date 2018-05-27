using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ISalesTerritoryHistoryRepository
	{
		Task<DTOSalesTerritoryHistory> Create(DTOSalesTerritoryHistory dto);

		Task Update(int businessEntityID,
		            DTOSalesTerritoryHistory dto);

		Task Delete(int businessEntityID);

		Task<DTOSalesTerritoryHistory> Get(int businessEntityID);

		Task<List<DTOSalesTerritoryHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>84d6f486470b43d7dd0a87eabe8b78d7</Hash>
</Codenesium>*/
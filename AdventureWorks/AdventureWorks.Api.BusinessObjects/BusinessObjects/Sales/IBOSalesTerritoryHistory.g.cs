using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesTerritoryHistory
	{
		Task<CreateResponse<POCOSalesTerritoryHistory>> Create(
			ApiSalesTerritoryHistoryModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiSalesTerritoryHistoryModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<POCOSalesTerritoryHistory> Get(int businessEntityID);

		Task<List<POCOSalesTerritoryHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ca9a7090bd26a56ca469ac367174addb</Hash>
</Codenesium>*/
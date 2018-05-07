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
		Task<CreateResponse<int>> Create(
			SalesTerritoryHistoryModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            SalesTerritoryHistoryModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOSalesTerritoryHistory Get(int businessEntityID);

		List<POCOSalesTerritoryHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8ed05f09a1a05ea495cd27c9b2543dd7</Hash>
</Codenesium>*/
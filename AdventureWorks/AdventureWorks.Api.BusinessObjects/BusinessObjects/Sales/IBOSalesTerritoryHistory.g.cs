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

		POCOSalesTerritoryHistory Get(int businessEntityID);

		List<POCOSalesTerritoryHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b71d27a2c441373af3c65c1846a025e4</Hash>
</Codenesium>*/
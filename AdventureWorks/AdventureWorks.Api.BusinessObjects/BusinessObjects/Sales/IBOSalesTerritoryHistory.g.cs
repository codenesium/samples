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
		Task<CreateResponse<ApiSalesTerritoryHistoryResponseModel>> Create(
			ApiSalesTerritoryHistoryRequestModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiSalesTerritoryHistoryRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiSalesTerritoryHistoryResponseModel> Get(int businessEntityID);

		Task<List<ApiSalesTerritoryHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a7d70cad207b2443bd50d40870b82ab4</Hash>
</Codenesium>*/
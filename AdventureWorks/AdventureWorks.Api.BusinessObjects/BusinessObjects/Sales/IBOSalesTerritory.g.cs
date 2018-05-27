using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOSalesTerritory
	{
		Task<CreateResponse<ApiSalesTerritoryResponseModel>> Create(
			ApiSalesTerritoryRequestModel model);

		Task<ActionResponse> Update(int territoryID,
		                            ApiSalesTerritoryRequestModel model);

		Task<ActionResponse> Delete(int territoryID);

		Task<ApiSalesTerritoryResponseModel> Get(int territoryID);

		Task<List<ApiSalesTerritoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiSalesTerritoryResponseModel> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>f266eb22c729e775816a41da01e2dfef</Hash>
</Codenesium>*/
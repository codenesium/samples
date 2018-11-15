using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface ISalesTerritoryService
	{
		Task<CreateResponse<ApiSalesTerritoryServerResponseModel>> Create(
			ApiSalesTerritoryServerRequestModel model);

		Task<UpdateResponse<ApiSalesTerritoryServerResponseModel>> Update(int territoryID,
		                                                                   ApiSalesTerritoryServerRequestModel model);

		Task<ActionResponse> Delete(int territoryID);

		Task<ApiSalesTerritoryServerResponseModel> Get(int territoryID);

		Task<List<ApiSalesTerritoryServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiSalesTerritoryServerResponseModel> ByName(string name);

		Task<ApiSalesTerritoryServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiCustomerServerResponseModel>> CustomersByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSalesPersonServerResponseModel>> SalesPersonsByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bfb58d329f735d3d14054da89a4a0f53</Hash>
</Codenesium>*/
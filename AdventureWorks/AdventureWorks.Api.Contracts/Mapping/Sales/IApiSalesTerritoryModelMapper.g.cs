using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiSalesTerritoryModelMapper
	{
		ApiSalesTerritoryResponseModel MapRequestToResponse(
			int territoryID,
			ApiSalesTerritoryRequestModel request);

		ApiSalesTerritoryRequestModel MapResponseToRequest(
			ApiSalesTerritoryResponseModel response);

		JsonPatchDocument<ApiSalesTerritoryRequestModel> CreatePatch(ApiSalesTerritoryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3881cd725b6eed5705e2a2a73ae8122d</Hash>
</Codenesium>*/
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
    <Hash>f69b78031d9e01188b736c72b2d3c808</Hash>
</Codenesium>*/
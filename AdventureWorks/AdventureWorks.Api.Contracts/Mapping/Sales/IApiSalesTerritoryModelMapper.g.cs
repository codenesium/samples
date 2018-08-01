using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiSalesTerritoryModelMapper
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
    <Hash>df8b140d50c93e4f2dbb51b45d59df15</Hash>
</Codenesium>*/
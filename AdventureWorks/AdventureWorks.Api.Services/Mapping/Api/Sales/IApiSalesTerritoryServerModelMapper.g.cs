using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesTerritoryServerModelMapper
	{
		ApiSalesTerritoryServerResponseModel MapServerRequestToResponse(
			int territoryID,
			ApiSalesTerritoryServerRequestModel request);

		ApiSalesTerritoryServerRequestModel MapServerResponseToRequest(
			ApiSalesTerritoryServerResponseModel response);

		ApiSalesTerritoryClientRequestModel MapServerResponseToClientRequest(
			ApiSalesTerritoryServerResponseModel response);

		JsonPatchDocument<ApiSalesTerritoryServerRequestModel> CreatePatch(ApiSalesTerritoryServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>6882bab1acc47a36c7da0f47d89cfe37</Hash>
</Codenesium>*/
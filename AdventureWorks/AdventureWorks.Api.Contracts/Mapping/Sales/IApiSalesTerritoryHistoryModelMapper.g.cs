using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiSalesTerritoryHistoryModelMapper
	{
		ApiSalesTerritoryHistoryResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiSalesTerritoryHistoryRequestModel request);

		ApiSalesTerritoryHistoryRequestModel MapResponseToRequest(
			ApiSalesTerritoryHistoryResponseModel response);

		JsonPatchDocument<ApiSalesTerritoryHistoryRequestModel> CreatePatch(ApiSalesTerritoryHistoryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>933a231c066c921b1fbfceb190fb96c6</Hash>
</Codenesium>*/
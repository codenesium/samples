using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiSalesTerritoryHistoryModelMapper
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
    <Hash>16d6bee23d1da1d9710c21c05c63e9c5</Hash>
</Codenesium>*/
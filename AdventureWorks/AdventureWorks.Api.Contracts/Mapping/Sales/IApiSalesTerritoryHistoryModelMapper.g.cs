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
    <Hash>173739068be84739d953b1d104777d24</Hash>
</Codenesium>*/
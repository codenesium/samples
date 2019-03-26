using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiSalesOrderHeaderServerModelMapper
	{
		ApiSalesOrderHeaderServerResponseModel MapServerRequestToResponse(
			int salesOrderID,
			ApiSalesOrderHeaderServerRequestModel request);

		ApiSalesOrderHeaderServerRequestModel MapServerResponseToRequest(
			ApiSalesOrderHeaderServerResponseModel response);

		ApiSalesOrderHeaderClientRequestModel MapServerResponseToClientRequest(
			ApiSalesOrderHeaderServerResponseModel response);

		JsonPatchDocument<ApiSalesOrderHeaderServerRequestModel> CreatePatch(ApiSalesOrderHeaderServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>260238be1e6cf5baa1593d3e910c94e8</Hash>
</Codenesium>*/
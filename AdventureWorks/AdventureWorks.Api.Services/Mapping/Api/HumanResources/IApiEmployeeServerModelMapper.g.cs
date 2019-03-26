using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiEmployeeServerModelMapper
	{
		ApiEmployeeServerResponseModel MapServerRequestToResponse(
			int businessEntityID,
			ApiEmployeeServerRequestModel request);

		ApiEmployeeServerRequestModel MapServerResponseToRequest(
			ApiEmployeeServerResponseModel response);

		ApiEmployeeClientRequestModel MapServerResponseToClientRequest(
			ApiEmployeeServerResponseModel response);

		JsonPatchDocument<ApiEmployeeServerRequestModel> CreatePatch(ApiEmployeeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5968941529754e891a64a80187043651</Hash>
</Codenesium>*/
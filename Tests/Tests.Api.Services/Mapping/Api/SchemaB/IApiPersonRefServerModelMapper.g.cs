using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public partial interface IApiPersonRefServerModelMapper
	{
		ApiPersonRefServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPersonRefServerRequestModel request);

		ApiPersonRefServerRequestModel MapServerResponseToRequest(
			ApiPersonRefServerResponseModel response);

		ApiPersonRefClientRequestModel MapServerResponseToClientRequest(
			ApiPersonRefServerResponseModel response);

		JsonPatchDocument<ApiPersonRefServerRequestModel> CreatePatch(ApiPersonRefServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>61f1bf1ce59d967952d8497d518192f4</Hash>
</Codenesium>*/
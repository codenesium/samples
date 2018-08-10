using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiPersonModelMapper
	{
		ApiPersonResponseModel MapRequestToResponse(
			int personId,
			ApiPersonRequestModel request);

		ApiPersonRequestModel MapResponseToRequest(
			ApiPersonResponseModel response);

		JsonPatchDocument<ApiPersonRequestModel> CreatePatch(ApiPersonRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f046f583a57ce847ff018b7023b22175</Hash>
</Codenesium>*/
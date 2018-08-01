using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiHandlerModelMapper
	{
		ApiHandlerResponseModel MapRequestToResponse(
			int id,
			ApiHandlerRequestModel request);

		ApiHandlerRequestModel MapResponseToRequest(
			ApiHandlerResponseModel response);

		JsonPatchDocument<ApiHandlerRequestModel> CreatePatch(ApiHandlerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>971b893f9f1e611764e53414eb57fce8</Hash>
</Codenesium>*/
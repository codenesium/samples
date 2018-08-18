using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiHandlerModelMapper
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
    <Hash>143aac945507b253bc309014b06b7817</Hash>
</Codenesium>*/
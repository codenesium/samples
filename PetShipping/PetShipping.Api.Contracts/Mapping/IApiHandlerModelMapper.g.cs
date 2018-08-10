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
    <Hash>357451841c49d3453cb032644c42dbb5</Hash>
</Codenesium>*/
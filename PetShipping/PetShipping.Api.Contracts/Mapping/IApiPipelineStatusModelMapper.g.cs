using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiPipelineStatusModelMapper
	{
		ApiPipelineStatusResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStatusRequestModel request);

		ApiPipelineStatusRequestModel MapResponseToRequest(
			ApiPipelineStatusResponseModel response);

		JsonPatchDocument<ApiPipelineStatusRequestModel> CreatePatch(ApiPipelineStatusRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b19e659c6e983538d364e48baac30d9c</Hash>
</Codenesium>*/
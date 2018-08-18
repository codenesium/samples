using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiPipelineStatusModelMapper
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
    <Hash>9786bc72af7719c340ab0c8519a822a3</Hash>
</Codenesium>*/
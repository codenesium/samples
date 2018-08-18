using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiPipelineStepStatusModelMapper
	{
		public virtual ApiPipelineStepStatusResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStepStatusRequestModel request)
		{
			var response = new ApiPipelineStepStatusResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPipelineStepStatusRequestModel MapResponseToRequest(
			ApiPipelineStepStatusResponseModel response)
		{
			var request = new ApiPipelineStepStatusRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStepStatusRequestModel> CreatePatch(ApiPipelineStepStatusRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStepStatusRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>0179bc12762d37072293cac990124e80</Hash>
</Codenesium>*/
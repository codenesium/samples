using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiHandlerPipelineStepModelMapper
	{
		public virtual ApiHandlerPipelineStepResponseModel MapRequestToResponse(
			int id,
			ApiHandlerPipelineStepRequestModel request)
		{
			var response = new ApiHandlerPipelineStepResponseModel();
			response.SetProperties(id,
			                       request.HandlerId,
			                       request.PipelineStepId);
			return response;
		}

		public virtual ApiHandlerPipelineStepRequestModel MapResponseToRequest(
			ApiHandlerPipelineStepResponseModel response)
		{
			var request = new ApiHandlerPipelineStepRequestModel();
			request.SetProperties(
				response.HandlerId,
				response.PipelineStepId);
			return request;
		}

		public JsonPatchDocument<ApiHandlerPipelineStepRequestModel> CreatePatch(ApiHandlerPipelineStepRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiHandlerPipelineStepRequestModel>();
			patch.Replace(x => x.HandlerId, model.HandlerId);
			patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>a0d88642cbb0ec78da8afb698cb8a789</Hash>
</Codenesium>*/
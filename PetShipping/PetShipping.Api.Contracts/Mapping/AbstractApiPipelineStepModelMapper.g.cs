using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiPipelineStepModelMapper
	{
		public virtual ApiPipelineStepResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStepRequestModel request)
		{
			var response = new ApiPipelineStepResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.PipelineStepStatusId,
			                       request.ShipperId);
			return response;
		}

		public virtual ApiPipelineStepRequestModel MapResponseToRequest(
			ApiPipelineStepResponseModel response)
		{
			var request = new ApiPipelineStepRequestModel();
			request.SetProperties(
				response.Name,
				response.PipelineStepStatusId,
				response.ShipperId);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStepRequestModel> CreatePatch(ApiPipelineStepRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStepRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.PipelineStepStatusId, model.PipelineStepStatusId);
			patch.Replace(x => x.ShipperId, model.ShipperId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>922c7b011b8c1f5e06c9cb3d2e9f6d12</Hash>
</Codenesium>*/
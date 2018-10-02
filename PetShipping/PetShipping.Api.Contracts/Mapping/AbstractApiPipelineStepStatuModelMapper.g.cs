using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiPipelineStepStatuModelMapper
	{
		public virtual ApiPipelineStepStatuResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStepStatuRequestModel request)
		{
			var response = new ApiPipelineStepStatuResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPipelineStepStatuRequestModel MapResponseToRequest(
			ApiPipelineStepStatuResponseModel response)
		{
			var request = new ApiPipelineStepStatuRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStepStatuRequestModel> CreatePatch(ApiPipelineStepStatuRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStepStatuRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>af41f96c413166350b50be1401bf1a1e</Hash>
</Codenesium>*/
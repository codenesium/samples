using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiPipelineStatuModelMapper
	{
		public virtual ApiPipelineStatuResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStatuRequestModel request)
		{
			var response = new ApiPipelineStatuResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPipelineStatuRequestModel MapResponseToRequest(
			ApiPipelineStatuResponseModel response)
		{
			var request = new ApiPipelineStatuRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStatuRequestModel> CreatePatch(ApiPipelineStatuRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStatuRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>a697d0f9da636728c6f226859efe4214</Hash>
</Codenesium>*/
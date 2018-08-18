using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiPipelineStatusModelMapper
	{
		public virtual ApiPipelineStatusResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStatusRequestModel request)
		{
			var response = new ApiPipelineStatusResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPipelineStatusRequestModel MapResponseToRequest(
			ApiPipelineStatusResponseModel response)
		{
			var request = new ApiPipelineStatusRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStatusRequestModel> CreatePatch(ApiPipelineStatusRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStatusRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>254a0407d306a13405f7fa725241571e</Hash>
</Codenesium>*/
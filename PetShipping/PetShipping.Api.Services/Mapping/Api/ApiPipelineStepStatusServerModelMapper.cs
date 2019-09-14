using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStepStatusServerModelMapper : IApiPipelineStepStatusServerModelMapper
	{
		public virtual ApiPipelineStepStatusServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStepStatusServerRequestModel request)
		{
			var response = new ApiPipelineStepStatusServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPipelineStepStatusServerRequestModel MapServerResponseToRequest(
			ApiPipelineStepStatusServerResponseModel response)
		{
			var request = new ApiPipelineStepStatusServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiPipelineStepStatusClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStepStatusServerResponseModel response)
		{
			var request = new ApiPipelineStepStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStepStatusServerRequestModel> CreatePatch(ApiPipelineStepStatusServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStepStatusServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>816da748fcb8a8815512ba3c86b33e9a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiOtherTransportServerModelMapper : IApiOtherTransportServerModelMapper
	{
		public virtual ApiOtherTransportServerResponseModel MapServerRequestToResponse(
			int id,
			ApiOtherTransportServerRequestModel request)
		{
			var response = new ApiOtherTransportServerResponseModel();
			response.SetProperties(id,
			                       request.HandlerId,
			                       request.PipelineStepId);
			return response;
		}

		public virtual ApiOtherTransportServerRequestModel MapServerResponseToRequest(
			ApiOtherTransportServerResponseModel response)
		{
			var request = new ApiOtherTransportServerRequestModel();
			request.SetProperties(
				response.HandlerId,
				response.PipelineStepId);
			return request;
		}

		public virtual ApiOtherTransportClientRequestModel MapServerResponseToClientRequest(
			ApiOtherTransportServerResponseModel response)
		{
			var request = new ApiOtherTransportClientRequestModel();
			request.SetProperties(
				response.HandlerId,
				response.PipelineStepId);
			return request;
		}

		public JsonPatchDocument<ApiOtherTransportServerRequestModel> CreatePatch(ApiOtherTransportServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiOtherTransportServerRequestModel>();
			patch.Replace(x => x.HandlerId, model.HandlerId);
			patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>708abe8dfa0be4a7c12793508a23276d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
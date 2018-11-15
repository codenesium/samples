using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiOtherTransportServerModelMapper
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
    <Hash>f9624a40de3503fded9f2a5fa7235395</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiOtherTransportModelMapper
	{
		public virtual ApiOtherTransportResponseModel MapRequestToResponse(
			int id,
			ApiOtherTransportRequestModel request)
		{
			var response = new ApiOtherTransportResponseModel();
			response.SetProperties(id,
			                       request.HandlerId,
			                       request.PipelineStepId);
			return response;
		}

		public virtual ApiOtherTransportRequestModel MapResponseToRequest(
			ApiOtherTransportResponseModel response)
		{
			var request = new ApiOtherTransportRequestModel();
			request.SetProperties(
				response.HandlerId,
				response.PipelineStepId);
			return request;
		}

		public JsonPatchDocument<ApiOtherTransportRequestModel> CreatePatch(ApiOtherTransportRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiOtherTransportRequestModel>();
			patch.Replace(x => x.HandlerId, model.HandlerId);
			patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>6c06d41c1b9440d3074e2db69e03f16b</Hash>
</Codenesium>*/
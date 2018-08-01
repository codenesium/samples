using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiPipelineStepDestinationModelMapper
	{
		public virtual ApiPipelineStepDestinationResponseModel MapRequestToResponse(
			int id,
			ApiPipelineStepDestinationRequestModel request)
		{
			var response = new ApiPipelineStepDestinationResponseModel();
			response.SetProperties(id,
			                       request.DestinationId,
			                       request.PipelineStepId);
			return response;
		}

		public virtual ApiPipelineStepDestinationRequestModel MapResponseToRequest(
			ApiPipelineStepDestinationResponseModel response)
		{
			var request = new ApiPipelineStepDestinationRequestModel();
			request.SetProperties(
				response.DestinationId,
				response.PipelineStepId);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStepDestinationRequestModel> CreatePatch(ApiPipelineStepDestinationRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStepDestinationRequestModel>();
			patch.Replace(x => x.DestinationId, model.DestinationId);
			patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>24529915f508627706628a347a9b6cbe</Hash>
</Codenesium>*/
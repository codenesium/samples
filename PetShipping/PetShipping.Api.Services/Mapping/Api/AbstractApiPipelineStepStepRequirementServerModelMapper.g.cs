using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineStepStepRequirementServerModelMapper
	{
		public virtual ApiPipelineStepStepRequirementServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineStepStepRequirementServerRequestModel request)
		{
			var response = new ApiPipelineStepStepRequirementServerResponseModel();
			response.SetProperties(id,
			                       request.Details,
			                       request.PipelineStepId,
			                       request.RequirementMet);
			return response;
		}

		public virtual ApiPipelineStepStepRequirementServerRequestModel MapServerResponseToRequest(
			ApiPipelineStepStepRequirementServerResponseModel response)
		{
			var request = new ApiPipelineStepStepRequirementServerRequestModel();
			request.SetProperties(
				response.Details,
				response.PipelineStepId,
				response.RequirementMet);
			return request;
		}

		public virtual ApiPipelineStepStepRequirementClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineStepStepRequirementServerResponseModel response)
		{
			var request = new ApiPipelineStepStepRequirementClientRequestModel();
			request.SetProperties(
				response.Details,
				response.PipelineStepId,
				response.RequirementMet);
			return request;
		}

		public JsonPatchDocument<ApiPipelineStepStepRequirementServerRequestModel> CreatePatch(ApiPipelineStepStepRequirementServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineStepStepRequirementServerRequestModel>();
			patch.Replace(x => x.Details, model.Details);
			patch.Replace(x => x.PipelineStepId, model.PipelineStepId);
			patch.Replace(x => x.RequirementMet, model.RequirementMet);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>c930e7e5ba269a7973ad09f3333b6033</Hash>
</Codenesium>*/
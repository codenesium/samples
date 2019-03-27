using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiPipelineStepStepRequirementModelMapper
	{
		public virtual ApiPipelineStepStepRequirementClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStepStepRequirementClientRequestModel request)
		{
			var response = new ApiPipelineStepStepRequirementClientResponseModel();
			response.SetProperties(id,
			                       request.Details,
			                       request.PipelineStepId,
			                       request.RequirementMet);
			return response;
		}

		public virtual ApiPipelineStepStepRequirementClientRequestModel MapClientResponseToRequest(
			ApiPipelineStepStepRequirementClientResponseModel response)
		{
			var request = new ApiPipelineStepStepRequirementClientRequestModel();
			request.SetProperties(
				response.Details,
				response.PipelineStepId,
				response.RequirementMet);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>33ae3ccef67b6118616094d2e6c15785</Hash>
</Codenesium>*/
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
			                       request.Detail,
			                       request.PipelineStepId,
			                       request.RequirementMet);
			return response;
		}

		public virtual ApiPipelineStepStepRequirementClientRequestModel MapClientResponseToRequest(
			ApiPipelineStepStepRequirementClientResponseModel response)
		{
			var request = new ApiPipelineStepStepRequirementClientRequestModel();
			request.SetProperties(
				response.Detail,
				response.PipelineStepId,
				response.RequirementMet);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>f219827920a9fecf36945427a547cdf0</Hash>
</Codenesium>*/
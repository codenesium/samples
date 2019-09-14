using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiPipelineStepStepRequirementModelMapper : IApiPipelineStepStepRequirementModelMapper
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
    <Hash>17239ecd97e88ee0dfda57a41a85b345</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
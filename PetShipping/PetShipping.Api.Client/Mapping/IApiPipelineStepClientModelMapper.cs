using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiPipelineStepModelMapper
	{
		ApiPipelineStepClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStepClientRequestModel request);

		ApiPipelineStepClientRequestModel MapClientResponseToRequest(
			ApiPipelineStepClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>c3979d6c1bc8a30fc7e1f66b77d80b66</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
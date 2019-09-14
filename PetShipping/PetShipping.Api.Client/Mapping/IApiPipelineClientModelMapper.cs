using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiPipelineModelMapper
	{
		ApiPipelineClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineClientRequestModel request);

		ApiPipelineClientRequestModel MapClientResponseToRequest(
			ApiPipelineClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>d73f6ba9aa6895faf4f0a9cf06332681</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiPipelineStatusModelMapper
	{
		ApiPipelineStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStatusClientRequestModel request);

		ApiPipelineStatusClientRequestModel MapClientResponseToRequest(
			ApiPipelineStatusClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>a40e6814fb2aa78de31f7fc5ab008c44</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public partial interface IApiPipelineStatuModelMapper
	{
		ApiPipelineStatuClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStatuClientRequestModel request);

		ApiPipelineStatuClientRequestModel MapClientResponseToRequest(
			ApiPipelineStatuClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>9116fde2024c9bddbc02e7818181d34b</Hash>
</Codenesium>*/
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
    <Hash>b38e237bd1b7a69739ff53b6ec582df2</Hash>
</Codenesium>*/
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
    <Hash>bd28a96be65d60fbf0d793926bd53f03</Hash>
</Codenesium>*/
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiEventStatuModelMapper
	{
		ApiEventStatuClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventStatuClientRequestModel request);

		ApiEventStatuClientRequestModel MapClientResponseToRequest(
			ApiEventStatuClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>247c8d21683cf042137322f3e8fe9120</Hash>
</Codenesium>*/
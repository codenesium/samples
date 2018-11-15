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
    <Hash>3f13fee55e6e293c154ede3b4da013b6</Hash>
</Codenesium>*/
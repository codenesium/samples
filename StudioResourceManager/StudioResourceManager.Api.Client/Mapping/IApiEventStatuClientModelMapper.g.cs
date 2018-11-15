using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
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
    <Hash>412de99ea803addad7c37d696df5810c</Hash>
</Codenesium>*/
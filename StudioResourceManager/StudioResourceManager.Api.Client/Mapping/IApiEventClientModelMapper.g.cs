using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public partial interface IApiEventModelMapper
	{
		ApiEventClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventClientRequestModel request);

		ApiEventClientRequestModel MapClientResponseToRequest(
			ApiEventClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>5ad5e06749825a28bdcab9f8460ed8c1</Hash>
</Codenesium>*/
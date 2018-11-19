using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public partial interface IApiRateModelMapper
	{
		ApiRateClientResponseModel MapClientRequestToResponse(
			int id,
			ApiRateClientRequestModel request);

		ApiRateClientRequestModel MapClientResponseToRequest(
			ApiRateClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>834cd91907a320e7ecc80d8b7d9031a0</Hash>
</Codenesium>*/
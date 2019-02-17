using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>8f70a006f5eac799a0a151bf09f66457</Hash>
</Codenesium>*/
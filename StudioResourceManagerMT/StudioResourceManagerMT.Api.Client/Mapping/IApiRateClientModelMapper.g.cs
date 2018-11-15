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
    <Hash>81f6687131527fd4b1bf390dd6a24831</Hash>
</Codenesium>*/
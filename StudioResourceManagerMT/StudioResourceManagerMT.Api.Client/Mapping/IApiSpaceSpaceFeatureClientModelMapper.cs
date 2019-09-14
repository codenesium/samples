using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiSpaceSpaceFeatureModelMapper
	{
		ApiSpaceSpaceFeatureClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSpaceSpaceFeatureClientRequestModel request);

		ApiSpaceSpaceFeatureClientRequestModel MapClientResponseToRequest(
			ApiSpaceSpaceFeatureClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>da31051949ab6909c4caf943eeea5a74</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
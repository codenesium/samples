using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiSpaceFeatureModelMapper
	{
		ApiSpaceFeatureClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSpaceFeatureClientRequestModel request);

		ApiSpaceFeatureClientRequestModel MapClientResponseToRequest(
			ApiSpaceFeatureClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>2c8366fbb341837eb224ca478656cadb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
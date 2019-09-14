using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
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
    <Hash>b3b3a2419e081b9ffbbc9a8d369740f8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
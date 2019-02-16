using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public partial interface IApiSpaceModelMapper
	{
		ApiSpaceClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSpaceClientRequestModel request);

		ApiSpaceClientRequestModel MapClientResponseToRequest(
			ApiSpaceClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>18e1e8a43913b1fb35a8274d10c95eda</Hash>
</Codenesium>*/
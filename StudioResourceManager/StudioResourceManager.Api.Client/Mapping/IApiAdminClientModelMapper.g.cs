using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public partial interface IApiAdminModelMapper
	{
		ApiAdminClientResponseModel MapClientRequestToResponse(
			int id,
			ApiAdminClientRequestModel request);

		ApiAdminClientRequestModel MapClientResponseToRequest(
			ApiAdminClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>46e4230475b08bc108838f848cd1b693</Hash>
</Codenesium>*/
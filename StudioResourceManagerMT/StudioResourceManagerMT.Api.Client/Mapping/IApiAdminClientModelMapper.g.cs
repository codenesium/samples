using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>2c9882645d72c164185f659b9b5edc72</Hash>
</Codenesium>*/
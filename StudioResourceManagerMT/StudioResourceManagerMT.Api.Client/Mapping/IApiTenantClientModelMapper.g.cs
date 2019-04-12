using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiTenantModelMapper
	{
		ApiTenantClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTenantClientRequestModel request);

		ApiTenantClientRequestModel MapClientResponseToRequest(
			ApiTenantClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>9621a348ed19ee7dc9c60698829a3cae</Hash>
</Codenesium>*/
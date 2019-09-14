using StudioResourceManagerNS.Api.Contracts;
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
    <Hash>f36642df0c34329c3da567e6ca5006ab</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
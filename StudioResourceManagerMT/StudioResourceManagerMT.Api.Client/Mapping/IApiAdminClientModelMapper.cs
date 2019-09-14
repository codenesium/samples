using StudioResourceManagerMTNS.Api.Contracts;
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
    <Hash>742ec6b3abf44c256ed8d3ae248fdbe1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
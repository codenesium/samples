using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiEventModelMapper
	{
		ApiEventClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventClientRequestModel request);

		ApiEventClientRequestModel MapClientResponseToRequest(
			ApiEventClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>66452190bf736ca7572c59cadc50de2e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
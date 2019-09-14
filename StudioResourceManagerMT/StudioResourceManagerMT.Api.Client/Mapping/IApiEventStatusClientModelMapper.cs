using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiEventStatusModelMapper
	{
		ApiEventStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventStatusClientRequestModel request);

		ApiEventStatusClientRequestModel MapClientResponseToRequest(
			ApiEventStatusClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>d0a3b3f5294b84601ef25c70095953da</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
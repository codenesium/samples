using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public partial interface IApiClaspModelMapper
	{
		ApiClaspClientResponseModel MapClientRequestToResponse(
			int id,
			ApiClaspClientRequestModel request);

		ApiClaspClientRequestModel MapClientResponseToRequest(
			ApiClaspClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>f24a80b715274058a94f0f849e937fa7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
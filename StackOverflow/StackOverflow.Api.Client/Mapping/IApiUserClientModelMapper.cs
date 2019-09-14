using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiUserModelMapper
	{
		ApiUserClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUserClientRequestModel request);

		ApiUserClientRequestModel MapClientResponseToRequest(
			ApiUserClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>0ce4a1d0dfff057f35a0b6650ff389d6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Client
{
	public partial interface IApiTableModelMapper
	{
		ApiTableClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTableClientRequestModel request);

		ApiTableClientRequestModel MapClientResponseToRequest(
			ApiTableClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>9d441a5f813fb344429af7113c8e06bb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
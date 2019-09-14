using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Client
{
	public partial interface IApiUserModelMapper
	{
		ApiUserClientResponseModel MapClientRequestToResponse(
			int userId,
			ApiUserClientRequestModel request);

		ApiUserClientRequestModel MapClientResponseToRequest(
			ApiUserClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>b80935dec2bab59d169b8574a67df9e7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
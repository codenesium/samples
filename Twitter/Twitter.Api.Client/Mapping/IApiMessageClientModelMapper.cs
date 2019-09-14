using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Client
{
	public partial interface IApiMessageModelMapper
	{
		ApiMessageClientResponseModel MapClientRequestToResponse(
			int messageId,
			ApiMessageClientRequestModel request);

		ApiMessageClientRequestModel MapClientResponseToRequest(
			ApiMessageClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>35e28ec918e7c13992185df9064bfcec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
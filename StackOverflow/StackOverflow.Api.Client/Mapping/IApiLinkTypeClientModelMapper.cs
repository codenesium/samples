using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiLinkTypeModelMapper
	{
		ApiLinkTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiLinkTypeClientRequestModel request);

		ApiLinkTypeClientRequestModel MapClientResponseToRequest(
			ApiLinkTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>11919534e261174e13411f6564b7b246</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
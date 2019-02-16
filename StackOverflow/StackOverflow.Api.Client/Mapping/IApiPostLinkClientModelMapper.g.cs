using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiPostLinkModelMapper
	{
		ApiPostLinkClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostLinkClientRequestModel request);

		ApiPostLinkClientRequestModel MapClientResponseToRequest(
			ApiPostLinkClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>54f2cd58f606a466fb08faa974b2d9bf</Hash>
</Codenesium>*/
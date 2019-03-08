using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiPostsModelMapper
	{
		ApiPostsClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostsClientRequestModel request);

		ApiPostsClientRequestModel MapClientResponseToRequest(
			ApiPostsClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>cf92c12e0b75b1e1fa403d33342632b2</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiPostTypeModelMapper
	{
		ApiPostTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostTypeClientRequestModel request);

		ApiPostTypeClientRequestModel MapClientResponseToRequest(
			ApiPostTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>a53b6ce3d2b9c17bb7c4afa81d8cc6f3</Hash>
</Codenesium>*/
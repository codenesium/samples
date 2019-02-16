using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiPostModelMapper
	{
		ApiPostClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostClientRequestModel request);

		ApiPostClientRequestModel MapClientResponseToRequest(
			ApiPostClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>de5824768fc951d354475a20aeb9a7d8</Hash>
</Codenesium>*/
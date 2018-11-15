using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public partial interface IApiIncludedColumnTestModelMapper
	{
		ApiIncludedColumnTestClientResponseModel MapClientRequestToResponse(
			int id,
			ApiIncludedColumnTestClientRequestModel request);

		ApiIncludedColumnTestClientRequestModel MapClientResponseToRequest(
			ApiIncludedColumnTestClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>01a5acffc17135ad44435101ba7f2c81</Hash>
</Codenesium>*/
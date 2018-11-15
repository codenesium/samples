using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public partial interface IApiPersonModelMapper
	{
		ApiPersonClientResponseModel MapClientRequestToResponse(
			int personId,
			ApiPersonClientRequestModel request);

		ApiPersonClientRequestModel MapClientResponseToRequest(
			ApiPersonClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>ca9b5084d73e29f6bc6e4891071cfa67</Hash>
</Codenesium>*/
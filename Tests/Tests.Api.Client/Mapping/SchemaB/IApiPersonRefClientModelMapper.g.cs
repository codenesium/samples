using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public partial interface IApiPersonRefModelMapper
	{
		ApiPersonRefClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPersonRefClientRequestModel request);

		ApiPersonRefClientRequestModel MapClientResponseToRequest(
			ApiPersonRefClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>d362fe7136b00a77e49f84f6ef9c0844</Hash>
</Codenesium>*/
using SecureVideoCRMNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Client
{
	public partial interface IApiVideoModelMapper
	{
		ApiVideoClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVideoClientRequestModel request);

		ApiVideoClientRequestModel MapClientResponseToRequest(
			ApiVideoClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>70ced51f962ba5aa6369b670f78d8fab</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Client
{
	public partial interface IApiBucketModelMapper
	{
		ApiBucketClientResponseModel MapClientRequestToResponse(
			int id,
			ApiBucketClientRequestModel request);

		ApiBucketClientRequestModel MapClientResponseToRequest(
			ApiBucketClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>c72ca97327aed9d3e7e8dafc1a3b30fb</Hash>
</Codenesium>*/
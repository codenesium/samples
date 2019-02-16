using FileServiceNS.Api.Contracts;
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
    <Hash>414fc7aa9f5b89496d295ef920c03d0e</Hash>
</Codenesium>*/
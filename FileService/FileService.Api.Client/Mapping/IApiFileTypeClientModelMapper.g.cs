using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Client
{
	public partial interface IApiFileTypeModelMapper
	{
		ApiFileTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiFileTypeClientRequestModel request);

		ApiFileTypeClientRequestModel MapClientResponseToRequest(
			ApiFileTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>3f5c5a190e7d7e76e9aaa69aef60b990</Hash>
</Codenesium>*/
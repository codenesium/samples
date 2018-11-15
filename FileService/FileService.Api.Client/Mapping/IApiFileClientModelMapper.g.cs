using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Client
{
	public partial interface IApiFileModelMapper
	{
		ApiFileClientResponseModel MapClientRequestToResponse(
			int id,
			ApiFileClientRequestModel request);

		ApiFileClientRequestModel MapClientResponseToRequest(
			ApiFileClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>47e7cab86205ee92f3247d595266b978</Hash>
</Codenesium>*/
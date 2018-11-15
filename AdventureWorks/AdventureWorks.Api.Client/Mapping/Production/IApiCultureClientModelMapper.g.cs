using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiCultureModelMapper
	{
		ApiCultureClientResponseModel MapClientRequestToResponse(
			string cultureID,
			ApiCultureClientRequestModel request);

		ApiCultureClientRequestModel MapClientResponseToRequest(
			ApiCultureClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>7acae76b16794e8fbbc8301eaccf3fa3</Hash>
</Codenesium>*/
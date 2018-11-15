using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiPersonModelMapper
	{
		ApiPersonClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiPersonClientRequestModel request);

		ApiPersonClientRequestModel MapClientResponseToRequest(
			ApiPersonClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>580df17f3f0cd1df240a167dc7ce7afd</Hash>
</Codenesium>*/
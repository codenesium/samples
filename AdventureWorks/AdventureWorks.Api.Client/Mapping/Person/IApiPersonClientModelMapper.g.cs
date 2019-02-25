using AdventureWorksNS.Api.Contracts;
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
    <Hash>9300414800fec405c2f7ebc153e833d8</Hash>
</Codenesium>*/
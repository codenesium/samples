using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiBusinessEntityModelMapper
	{
		ApiBusinessEntityClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiBusinessEntityClientRequestModel request);

		ApiBusinessEntityClientRequestModel MapClientResponseToRequest(
			ApiBusinessEntityClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>80a84b47b7709866ce95c00f40d95f2e</Hash>
</Codenesium>*/
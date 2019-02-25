using AdventureWorksNS.Api.Contracts;
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
    <Hash>109724d502a4c26ff29a05fbcb94ab5e</Hash>
</Codenesium>*/
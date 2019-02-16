using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiPasswordModelMapper
	{
		ApiPasswordClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiPasswordClientRequestModel request);

		ApiPasswordClientRequestModel MapClientResponseToRequest(
			ApiPasswordClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>3619d8276939ef92fbae8e33fca2653e</Hash>
</Codenesium>*/
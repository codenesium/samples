using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiPostLinksModelMapper
	{
		ApiPostLinksClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostLinksClientRequestModel request);

		ApiPostLinksClientRequestModel MapClientResponseToRequest(
			ApiPostLinksClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>7cd29e905cf1f36ece0959a4c7c5898d</Hash>
</Codenesium>*/
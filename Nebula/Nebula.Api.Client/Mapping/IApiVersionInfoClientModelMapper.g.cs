using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public partial interface IApiVersionInfoModelMapper
	{
		ApiVersionInfoClientResponseModel MapClientRequestToResponse(
			long version,
			ApiVersionInfoClientRequestModel request);

		ApiVersionInfoClientRequestModel MapClientResponseToRequest(
			ApiVersionInfoClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>84f0a69355d7149ad4a1662cf810a9e5</Hash>
</Codenesium>*/
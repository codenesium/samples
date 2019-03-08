using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiLinkTypesModelMapper
	{
		ApiLinkTypesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiLinkTypesClientRequestModel request);

		ApiLinkTypesClientRequestModel MapClientResponseToRequest(
			ApiLinkTypesClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>a8e572aa3aa26e36a4872210e13c979f</Hash>
</Codenesium>*/
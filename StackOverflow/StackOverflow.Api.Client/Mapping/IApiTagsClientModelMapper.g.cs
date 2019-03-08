using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiTagsModelMapper
	{
		ApiTagsClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTagsClientRequestModel request);

		ApiTagsClientRequestModel MapClientResponseToRequest(
			ApiTagsClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>21f4dbf8ff585479f5c4771b1bfec073</Hash>
</Codenesium>*/
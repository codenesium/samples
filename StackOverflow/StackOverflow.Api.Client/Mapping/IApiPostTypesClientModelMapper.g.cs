using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiPostTypesModelMapper
	{
		ApiPostTypesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostTypesClientRequestModel request);

		ApiPostTypesClientRequestModel MapClientResponseToRequest(
			ApiPostTypesClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>4083ec965fd0751172708a7a597a9135</Hash>
</Codenesium>*/
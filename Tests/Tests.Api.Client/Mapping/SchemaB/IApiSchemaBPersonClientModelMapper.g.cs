using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public partial interface IApiSchemaBPersonModelMapper
	{
		ApiSchemaBPersonClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSchemaBPersonClientRequestModel request);

		ApiSchemaBPersonClientRequestModel MapClientResponseToRequest(
			ApiSchemaBPersonClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>018b27f0c48dec87477dd86eb57034a6</Hash>
</Codenesium>*/
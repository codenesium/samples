using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Client
{
	public partial interface IApiTimestampCheckModelMapper
	{
		ApiTimestampCheckClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTimestampCheckClientRequestModel request);

		ApiTimestampCheckClientRequestModel MapClientResponseToRequest(
			ApiTimestampCheckClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>86908d3279150e82b0082330250a919e</Hash>
</Codenesium>*/
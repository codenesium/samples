using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    <Hash>9ea3a83803533583c104ec5d7732dabe</Hash>
</Codenesium>*/
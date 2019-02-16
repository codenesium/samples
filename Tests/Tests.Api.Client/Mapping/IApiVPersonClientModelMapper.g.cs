using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Client
{
	public partial interface IApiVPersonModelMapper
	{
		ApiVPersonClientResponseModel MapClientRequestToResponse(
			int personId,
			ApiVPersonClientRequestModel request);

		ApiVPersonClientRequestModel MapClientResponseToRequest(
			ApiVPersonClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>6103379522f4d55902dbabaaf600616c</Hash>
</Codenesium>*/
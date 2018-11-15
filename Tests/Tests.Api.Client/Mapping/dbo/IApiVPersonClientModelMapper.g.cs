using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    <Hash>6e3bf03017b9f1bf1b28efeb88caf392</Hash>
</Codenesium>*/
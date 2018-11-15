using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiPostModelMapper
	{
		ApiPostClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostClientRequestModel request);

		ApiPostClientRequestModel MapClientResponseToRequest(
			ApiPostClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>432111aa5c28bea466ac29c707e848bd</Hash>
</Codenesium>*/
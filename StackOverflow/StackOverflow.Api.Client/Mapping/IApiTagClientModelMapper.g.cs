using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiTagModelMapper
	{
		ApiTagClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTagClientRequestModel request);

		ApiTagClientRequestModel MapClientResponseToRequest(
			ApiTagClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>74ff410a9d11378c765c9d94cdda6354</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiWorkOrderModelMapper
	{
		ApiWorkOrderClientResponseModel MapClientRequestToResponse(
			int workOrderID,
			ApiWorkOrderClientRequestModel request);

		ApiWorkOrderClientRequestModel MapClientResponseToRequest(
			ApiWorkOrderClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>cec7b9b163a28173aacdc8abe19d1bc5</Hash>
</Codenesium>*/
using AdventureWorksNS.Api.Contracts;
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
    <Hash>6eb198bf3e8f8326c50c85be2db25526</Hash>
</Codenesium>*/
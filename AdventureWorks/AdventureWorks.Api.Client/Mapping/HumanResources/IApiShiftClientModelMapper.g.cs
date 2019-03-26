using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiShiftModelMapper
	{
		ApiShiftClientResponseModel MapClientRequestToResponse(
			int shiftID,
			ApiShiftClientRequestModel request);

		ApiShiftClientRequestModel MapClientResponseToRequest(
			ApiShiftClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>26a22c432e7433c793e2f46b5b5105dd</Hash>
</Codenesium>*/
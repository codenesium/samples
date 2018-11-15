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
    <Hash>1cca3c6115cc538dadd1dc9afabd80f0</Hash>
</Codenesium>*/
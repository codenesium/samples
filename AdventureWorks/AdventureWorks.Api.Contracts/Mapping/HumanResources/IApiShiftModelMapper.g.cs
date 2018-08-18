using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiShiftModelMapper
	{
		ApiShiftResponseModel MapRequestToResponse(
			int shiftID,
			ApiShiftRequestModel request);

		ApiShiftRequestModel MapResponseToRequest(
			ApiShiftResponseModel response);

		JsonPatchDocument<ApiShiftRequestModel> CreatePatch(ApiShiftRequestModel model);
	}
}

/*<Codenesium>
    <Hash>55985b6e3796079478c1fc577e23fa60</Hash>
</Codenesium>*/
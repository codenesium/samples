using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiShiftModelMapper
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
    <Hash>538bf296b7e44026db22a878f3c9dae2</Hash>
</Codenesium>*/
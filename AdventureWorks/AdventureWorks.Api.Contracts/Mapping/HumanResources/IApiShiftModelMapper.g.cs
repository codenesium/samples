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
    <Hash>af268d8b933633898b7f8989e5e9b5e6</Hash>
</Codenesium>*/
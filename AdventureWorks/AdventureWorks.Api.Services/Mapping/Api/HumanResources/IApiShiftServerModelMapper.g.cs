using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiShiftServerModelMapper
	{
		ApiShiftServerResponseModel MapServerRequestToResponse(
			int shiftID,
			ApiShiftServerRequestModel request);

		ApiShiftServerRequestModel MapServerResponseToRequest(
			ApiShiftServerResponseModel response);

		ApiShiftClientRequestModel MapServerResponseToClientRequest(
			ApiShiftServerResponseModel response);

		JsonPatchDocument<ApiShiftServerRequestModel> CreatePatch(ApiShiftServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7cdb0da85bebfaea7ff757c345d1b1ab</Hash>
</Codenesium>*/
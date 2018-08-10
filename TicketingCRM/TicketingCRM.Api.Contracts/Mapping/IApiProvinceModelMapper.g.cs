using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiProvinceModelMapper
	{
		ApiProvinceResponseModel MapRequestToResponse(
			int id,
			ApiProvinceRequestModel request);

		ApiProvinceRequestModel MapResponseToRequest(
			ApiProvinceResponseModel response);

		JsonPatchDocument<ApiProvinceRequestModel> CreatePatch(ApiProvinceRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4bc95821c4a734f9f99b24522b281ffe</Hash>
</Codenesium>*/
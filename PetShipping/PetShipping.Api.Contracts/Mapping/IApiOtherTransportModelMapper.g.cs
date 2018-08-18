using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiOtherTransportModelMapper
	{
		ApiOtherTransportResponseModel MapRequestToResponse(
			int id,
			ApiOtherTransportRequestModel request);

		ApiOtherTransportRequestModel MapResponseToRequest(
			ApiOtherTransportResponseModel response);

		JsonPatchDocument<ApiOtherTransportRequestModel> CreatePatch(ApiOtherTransportRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7e4ddc8d9a4d873624820942f83c28ec</Hash>
</Codenesium>*/
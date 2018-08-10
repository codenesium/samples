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
    <Hash>14eeddb88bc77ba9d019bf51aa613cc5</Hash>
</Codenesium>*/
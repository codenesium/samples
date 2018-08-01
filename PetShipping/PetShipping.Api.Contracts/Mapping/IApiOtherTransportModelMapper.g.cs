using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiOtherTransportModelMapper
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
    <Hash>42c07d887fcc243c05347ac0f5be6d3f</Hash>
</Codenesium>*/
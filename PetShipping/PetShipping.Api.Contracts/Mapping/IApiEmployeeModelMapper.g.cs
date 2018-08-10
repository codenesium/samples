using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiEmployeeModelMapper
	{
		ApiEmployeeResponseModel MapRequestToResponse(
			int id,
			ApiEmployeeRequestModel request);

		ApiEmployeeRequestModel MapResponseToRequest(
			ApiEmployeeResponseModel response);

		JsonPatchDocument<ApiEmployeeRequestModel> CreatePatch(ApiEmployeeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>ed399f8d51a34923f65e15e88fda84ae</Hash>
</Codenesium>*/
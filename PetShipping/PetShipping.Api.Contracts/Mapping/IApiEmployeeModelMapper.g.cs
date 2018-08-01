using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiEmployeeModelMapper
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
    <Hash>140c98ed8d624e74459d1c42381ef8ad</Hash>
</Codenesium>*/
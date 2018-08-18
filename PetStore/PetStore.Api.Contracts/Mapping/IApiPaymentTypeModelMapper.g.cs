using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
	public partial interface IApiPaymentTypeModelMapper
	{
		ApiPaymentTypeResponseModel MapRequestToResponse(
			int id,
			ApiPaymentTypeRequestModel request);

		ApiPaymentTypeRequestModel MapResponseToRequest(
			ApiPaymentTypeResponseModel response);

		JsonPatchDocument<ApiPaymentTypeRequestModel> CreatePatch(ApiPaymentTypeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4529b513f0f5468d7bff399fff27e62c</Hash>
</Codenesium>*/
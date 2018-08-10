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
    <Hash>d473adafe6f4d4fd2c88d808321fea96</Hash>
</Codenesium>*/
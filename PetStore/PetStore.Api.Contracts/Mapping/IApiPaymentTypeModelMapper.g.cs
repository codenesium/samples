using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
	public interface IApiPaymentTypeModelMapper
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
    <Hash>d2799a9696968bc52fd407a7af815aaf</Hash>
</Codenesium>*/
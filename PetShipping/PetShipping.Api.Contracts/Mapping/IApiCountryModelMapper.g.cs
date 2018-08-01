using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiCountryModelMapper
	{
		ApiCountryResponseModel MapRequestToResponse(
			int id,
			ApiCountryRequestModel request);

		ApiCountryRequestModel MapResponseToRequest(
			ApiCountryResponseModel response);

		JsonPatchDocument<ApiCountryRequestModel> CreatePatch(ApiCountryRequestModel model);
	}
}

/*<Codenesium>
    <Hash>92049a5051b5f973463325772d604948</Hash>
</Codenesium>*/
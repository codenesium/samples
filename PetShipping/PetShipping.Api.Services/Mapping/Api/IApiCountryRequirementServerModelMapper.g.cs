using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiCountryRequirementServerModelMapper
	{
		ApiCountryRequirementServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCountryRequirementServerRequestModel request);

		ApiCountryRequirementServerRequestModel MapServerResponseToRequest(
			ApiCountryRequirementServerResponseModel response);

		ApiCountryRequirementClientRequestModel MapServerResponseToClientRequest(
			ApiCountryRequirementServerResponseModel response);

		JsonPatchDocument<ApiCountryRequirementServerRequestModel> CreatePatch(ApiCountryRequirementServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e40726fd364fedcb8891ad27ba11d813</Hash>
</Codenesium>*/
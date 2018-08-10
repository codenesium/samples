using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiClientCommunicationModelMapper
	{
		ApiClientCommunicationResponseModel MapRequestToResponse(
			int id,
			ApiClientCommunicationRequestModel request);

		ApiClientCommunicationRequestModel MapResponseToRequest(
			ApiClientCommunicationResponseModel response);

		JsonPatchDocument<ApiClientCommunicationRequestModel> CreatePatch(ApiClientCommunicationRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d25cf55bf0ffa177e74b385e16168e4b</Hash>
</Codenesium>*/
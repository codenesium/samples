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
    <Hash>2a36a0885eb08cc9d9b13c4eac166e05</Hash>
</Codenesium>*/
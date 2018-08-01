using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiClientCommunicationModelMapper
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
    <Hash>ab75eaf0a0c627ac0561db1e105b678e</Hash>
</Codenesium>*/
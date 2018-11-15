using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiClientCommunicationServerModelMapper
	{
		ApiClientCommunicationServerResponseModel MapServerRequestToResponse(
			int id,
			ApiClientCommunicationServerRequestModel request);

		ApiClientCommunicationServerRequestModel MapServerResponseToRequest(
			ApiClientCommunicationServerResponseModel response);

		ApiClientCommunicationClientRequestModel MapServerResponseToClientRequest(
			ApiClientCommunicationServerResponseModel response);

		JsonPatchDocument<ApiClientCommunicationServerRequestModel> CreatePatch(ApiClientCommunicationServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>efbc4282ee7f4a7c38c1d2310645fe20</Hash>
</Codenesium>*/
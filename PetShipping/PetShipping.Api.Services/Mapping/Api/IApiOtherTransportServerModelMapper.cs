using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiOtherTransportServerModelMapper
	{
		ApiOtherTransportServerResponseModel MapServerRequestToResponse(
			int id,
			ApiOtherTransportServerRequestModel request);

		ApiOtherTransportServerRequestModel MapServerResponseToRequest(
			ApiOtherTransportServerResponseModel response);

		ApiOtherTransportClientRequestModel MapServerResponseToClientRequest(
			ApiOtherTransportServerResponseModel response);

		JsonPatchDocument<ApiOtherTransportServerRequestModel> CreatePatch(ApiOtherTransportServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5124fc9693d09649961cfae33f0f1c27</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
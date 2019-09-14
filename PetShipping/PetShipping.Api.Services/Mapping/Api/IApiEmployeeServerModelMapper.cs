using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiEmployeeServerModelMapper
	{
		ApiEmployeeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEmployeeServerRequestModel request);

		ApiEmployeeServerRequestModel MapServerResponseToRequest(
			ApiEmployeeServerResponseModel response);

		ApiEmployeeClientRequestModel MapServerResponseToClientRequest(
			ApiEmployeeServerResponseModel response);

		JsonPatchDocument<ApiEmployeeServerRequestModel> CreatePatch(ApiEmployeeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>1015fcb491e4383930e69e2dce0878d2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
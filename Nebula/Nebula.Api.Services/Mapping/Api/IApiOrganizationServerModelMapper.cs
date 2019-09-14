using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiOrganizationServerModelMapper
	{
		ApiOrganizationServerResponseModel MapServerRequestToResponse(
			int id,
			ApiOrganizationServerRequestModel request);

		ApiOrganizationServerRequestModel MapServerResponseToRequest(
			ApiOrganizationServerResponseModel response);

		ApiOrganizationClientRequestModel MapServerResponseToClientRequest(
			ApiOrganizationServerResponseModel response);

		JsonPatchDocument<ApiOrganizationServerRequestModel> CreatePatch(ApiOrganizationServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0f79861124f28038318b3c5926d84919</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
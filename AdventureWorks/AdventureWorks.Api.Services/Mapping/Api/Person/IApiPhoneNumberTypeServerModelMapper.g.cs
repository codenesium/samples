using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPhoneNumberTypeServerModelMapper
	{
		ApiPhoneNumberTypeServerResponseModel MapServerRequestToResponse(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeServerRequestModel request);

		ApiPhoneNumberTypeServerRequestModel MapServerResponseToRequest(
			ApiPhoneNumberTypeServerResponseModel response);

		ApiPhoneNumberTypeClientRequestModel MapServerResponseToClientRequest(
			ApiPhoneNumberTypeServerResponseModel response);

		JsonPatchDocument<ApiPhoneNumberTypeServerRequestModel> CreatePatch(ApiPhoneNumberTypeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>79f082b4f79524ee4399af22dbaa8d3e</Hash>
</Codenesium>*/
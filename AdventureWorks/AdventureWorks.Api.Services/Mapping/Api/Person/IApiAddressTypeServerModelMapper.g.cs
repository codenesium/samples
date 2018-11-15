using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiAddressTypeServerModelMapper
	{
		ApiAddressTypeServerResponseModel MapServerRequestToResponse(
			int addressTypeID,
			ApiAddressTypeServerRequestModel request);

		ApiAddressTypeServerRequestModel MapServerResponseToRequest(
			ApiAddressTypeServerResponseModel response);

		ApiAddressTypeClientRequestModel MapServerResponseToClientRequest(
			ApiAddressTypeServerResponseModel response);

		JsonPatchDocument<ApiAddressTypeServerRequestModel> CreatePatch(ApiAddressTypeServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>64cb9d36fae8d0d022047dabbf4dcdcc</Hash>
</Codenesium>*/
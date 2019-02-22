using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiAddressServerModelMapper
	{
		ApiAddressServerResponseModel MapServerRequestToResponse(
			int id,
			ApiAddressServerRequestModel request);

		ApiAddressServerRequestModel MapServerResponseToRequest(
			ApiAddressServerResponseModel response);

		ApiAddressClientRequestModel MapServerResponseToClientRequest(
			ApiAddressServerResponseModel response);

		JsonPatchDocument<ApiAddressServerRequestModel> CreatePatch(ApiAddressServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4367255ca69ada2a1904bb79a89663f8</Hash>
</Codenesium>*/
using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiUnitDispositionServerModelMapper
	{
		ApiUnitDispositionServerResponseModel MapServerRequestToResponse(
			int id,
			ApiUnitDispositionServerRequestModel request);

		ApiUnitDispositionServerRequestModel MapServerResponseToRequest(
			ApiUnitDispositionServerResponseModel response);

		ApiUnitDispositionClientRequestModel MapServerResponseToClientRequest(
			ApiUnitDispositionServerResponseModel response);

		JsonPatchDocument<ApiUnitDispositionServerRequestModel> CreatePatch(ApiUnitDispositionServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3d7da12ede46b03c7e10c72352d83982</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
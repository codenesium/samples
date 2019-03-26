using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiStateProvinceServerModelMapper
	{
		ApiStateProvinceServerResponseModel MapServerRequestToResponse(
			int stateProvinceID,
			ApiStateProvinceServerRequestModel request);

		ApiStateProvinceServerRequestModel MapServerResponseToRequest(
			ApiStateProvinceServerResponseModel response);

		ApiStateProvinceClientRequestModel MapServerResponseToClientRequest(
			ApiStateProvinceServerResponseModel response);

		JsonPatchDocument<ApiStateProvinceServerRequestModel> CreatePatch(ApiStateProvinceServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>2f78c331e9a963b21346e6cd98c1c956</Hash>
</Codenesium>*/
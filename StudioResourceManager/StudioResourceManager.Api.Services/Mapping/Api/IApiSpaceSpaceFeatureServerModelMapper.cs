using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiSpaceSpaceFeatureServerModelMapper
	{
		ApiSpaceSpaceFeatureServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSpaceSpaceFeatureServerRequestModel request);

		ApiSpaceSpaceFeatureServerRequestModel MapServerResponseToRequest(
			ApiSpaceSpaceFeatureServerResponseModel response);

		ApiSpaceSpaceFeatureClientRequestModel MapServerResponseToClientRequest(
			ApiSpaceSpaceFeatureServerResponseModel response);

		JsonPatchDocument<ApiSpaceSpaceFeatureServerRequestModel> CreatePatch(ApiSpaceSpaceFeatureServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>50cd281e4736383823e57c25fe75275e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
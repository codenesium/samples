using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial interface IApiSpaceSpaceFeatureModelMapper
	{
		ApiSpaceSpaceFeatureResponseModel MapRequestToResponse(
			int id,
			ApiSpaceSpaceFeatureRequestModel request);

		ApiSpaceSpaceFeatureRequestModel MapResponseToRequest(
			ApiSpaceSpaceFeatureResponseModel response);

		JsonPatchDocument<ApiSpaceSpaceFeatureRequestModel> CreatePatch(ApiSpaceSpaceFeatureRequestModel model);
	}
}

/*<Codenesium>
    <Hash>c6b6209e36c41cfca1c919f49da696cc</Hash>
</Codenesium>*/
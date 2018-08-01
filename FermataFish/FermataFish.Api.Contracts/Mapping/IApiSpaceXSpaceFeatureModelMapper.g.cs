using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public interface IApiSpaceXSpaceFeatureModelMapper
	{
		ApiSpaceXSpaceFeatureResponseModel MapRequestToResponse(
			int id,
			ApiSpaceXSpaceFeatureRequestModel request);

		ApiSpaceXSpaceFeatureRequestModel MapResponseToRequest(
			ApiSpaceXSpaceFeatureResponseModel response);

		JsonPatchDocument<ApiSpaceXSpaceFeatureRequestModel> CreatePatch(ApiSpaceXSpaceFeatureRequestModel model);
	}
}

/*<Codenesium>
    <Hash>615b96c60aa095c9c2b79f906acb4baa</Hash>
</Codenesium>*/
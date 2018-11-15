using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiUnitMeasureServerModelMapper
	{
		ApiUnitMeasureServerResponseModel MapServerRequestToResponse(
			string unitMeasureCode,
			ApiUnitMeasureServerRequestModel request);

		ApiUnitMeasureServerRequestModel MapServerResponseToRequest(
			ApiUnitMeasureServerResponseModel response);

		ApiUnitMeasureClientRequestModel MapServerResponseToClientRequest(
			ApiUnitMeasureServerResponseModel response);

		JsonPatchDocument<ApiUnitMeasureServerRequestModel> CreatePatch(ApiUnitMeasureServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e4a00b66ba1fd43fc19579f2874101c9</Hash>
</Codenesium>*/
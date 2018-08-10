using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiUnitMeasureModelMapper
	{
		ApiUnitMeasureResponseModel MapRequestToResponse(
			string unitMeasureCode,
			ApiUnitMeasureRequestModel request);

		ApiUnitMeasureRequestModel MapResponseToRequest(
			ApiUnitMeasureResponseModel response);

		JsonPatchDocument<ApiUnitMeasureRequestModel> CreatePatch(ApiUnitMeasureRequestModel model);
	}
}

/*<Codenesium>
    <Hash>28ba83d3dfa0ac63460ccf0e5debf519</Hash>
</Codenesium>*/
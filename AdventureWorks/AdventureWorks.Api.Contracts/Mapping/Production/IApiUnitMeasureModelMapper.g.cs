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
    <Hash>417aa6c4533019e9e55740cdd83076c3</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiUnitMeasureModelMapper
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
    <Hash>5cc7c1de78deb7f56f112d4cde2429a2</Hash>
</Codenesium>*/
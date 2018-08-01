using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiUnitMeasureModelMapper
	{
		public virtual ApiUnitMeasureResponseModel MapRequestToResponse(
			string unitMeasureCode,
			ApiUnitMeasureRequestModel request)
		{
			var response = new ApiUnitMeasureResponseModel();
			response.SetProperties(unitMeasureCode,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiUnitMeasureRequestModel MapResponseToRequest(
			ApiUnitMeasureResponseModel response)
		{
			var request = new ApiUnitMeasureRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiUnitMeasureRequestModel> CreatePatch(ApiUnitMeasureRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUnitMeasureRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>250697daf752232414e77503cccc9fb1</Hash>
</Codenesium>*/
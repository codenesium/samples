using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiUnitMeasureServerModelMapper
	{
		public virtual ApiUnitMeasureServerResponseModel MapServerRequestToResponse(
			string unitMeasureCode,
			ApiUnitMeasureServerRequestModel request)
		{
			var response = new ApiUnitMeasureServerResponseModel();
			response.SetProperties(unitMeasureCode,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiUnitMeasureServerRequestModel MapServerResponseToRequest(
			ApiUnitMeasureServerResponseModel response)
		{
			var request = new ApiUnitMeasureServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public virtual ApiUnitMeasureClientRequestModel MapServerResponseToClientRequest(
			ApiUnitMeasureServerResponseModel response)
		{
			var request = new ApiUnitMeasureClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiUnitMeasureServerRequestModel> CreatePatch(ApiUnitMeasureServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUnitMeasureServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8ce4a28350516c5a0e114bf4f5379927</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public abstract class AbstractApiLocationModelMapper
	{
		public virtual ApiLocationResponseModel MapRequestToResponse(
			int locationId,
			ApiLocationRequestModel request)
		{
			var response = new ApiLocationResponseModel();
			response.SetProperties(locationId,
			                       request.GpsLat,
			                       request.GpsLong,
			                       request.LocationName);
			return response;
		}

		public virtual ApiLocationRequestModel MapResponseToRequest(
			ApiLocationResponseModel response)
		{
			var request = new ApiLocationRequestModel();
			request.SetProperties(
				response.GpsLat,
				response.GpsLong,
				response.LocationName);
			return request;
		}

		public JsonPatchDocument<ApiLocationRequestModel> CreatePatch(ApiLocationRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLocationRequestModel>();
			patch.Replace(x => x.GpsLat, model.GpsLat);
			patch.Replace(x => x.GpsLong, model.GpsLong);
			patch.Replace(x => x.LocationName, model.LocationName);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>54ecd49b224e6847c54b20d78d450c09</Hash>
</Codenesium>*/
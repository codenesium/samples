using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public class ApiLocationServerModelMapper : IApiLocationServerModelMapper
	{
		public virtual ApiLocationServerResponseModel MapServerRequestToResponse(
			int locationId,
			ApiLocationServerRequestModel request)
		{
			var response = new ApiLocationServerResponseModel();
			response.SetProperties(locationId,
			                       request.GpsLat,
			                       request.GpsLong,
			                       request.LocationName);
			return response;
		}

		public virtual ApiLocationServerRequestModel MapServerResponseToRequest(
			ApiLocationServerResponseModel response)
		{
			var request = new ApiLocationServerRequestModel();
			request.SetProperties(
				response.GpsLat,
				response.GpsLong,
				response.LocationName);
			return request;
		}

		public virtual ApiLocationClientRequestModel MapServerResponseToClientRequest(
			ApiLocationServerResponseModel response)
		{
			var request = new ApiLocationClientRequestModel();
			request.SetProperties(
				response.GpsLat,
				response.GpsLong,
				response.LocationName);
			return request;
		}

		public JsonPatchDocument<ApiLocationServerRequestModel> CreatePatch(ApiLocationServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLocationServerRequestModel>();
			patch.Replace(x => x.GpsLat, model.GpsLat);
			patch.Replace(x => x.GpsLong, model.GpsLong);
			patch.Replace(x => x.LocationName, model.LocationName);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9338bec246ba9ca9ce0e363250194ff6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
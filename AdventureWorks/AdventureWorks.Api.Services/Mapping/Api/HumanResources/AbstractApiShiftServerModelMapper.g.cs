using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiShiftServerModelMapper
	{
		public virtual ApiShiftServerResponseModel MapServerRequestToResponse(
			int shiftID,
			ApiShiftServerRequestModel request)
		{
			var response = new ApiShiftServerResponseModel();
			response.SetProperties(shiftID,
			                       request.EndTime,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.StartTime);
			return response;
		}

		public virtual ApiShiftServerRequestModel MapServerResponseToRequest(
			ApiShiftServerResponseModel response)
		{
			var request = new ApiShiftServerRequestModel();
			request.SetProperties(
				response.EndTime,
				response.ModifiedDate,
				response.Name,
				response.StartTime);
			return request;
		}

		public virtual ApiShiftClientRequestModel MapServerResponseToClientRequest(
			ApiShiftServerResponseModel response)
		{
			var request = new ApiShiftClientRequestModel();
			request.SetProperties(
				response.EndTime,
				response.ModifiedDate,
				response.Name,
				response.StartTime);
			return request;
		}

		public JsonPatchDocument<ApiShiftServerRequestModel> CreatePatch(ApiShiftServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiShiftServerRequestModel>();
			patch.Replace(x => x.EndTime, model.EndTime);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.StartTime, model.StartTime);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>4ee4301b00be91517e189df2da9f3a84</Hash>
</Codenesium>*/
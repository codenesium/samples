using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public abstract class AbstractApiMessengerModelMapper
	{
		public virtual ApiMessengerResponseModel MapRequestToResponse(
			int id,
			ApiMessengerRequestModel request)
		{
			var response = new ApiMessengerResponseModel();
			response.SetProperties(id,
			                       request.Date,
			                       request.FromUserId,
			                       request.MessageId,
			                       request.Time,
			                       request.ToUserId,
			                       request.UserId);
			return response;
		}

		public virtual ApiMessengerRequestModel MapResponseToRequest(
			ApiMessengerResponseModel response)
		{
			var request = new ApiMessengerRequestModel();
			request.SetProperties(
				response.Date,
				response.FromUserId,
				response.MessageId,
				response.Time,
				response.ToUserId,
				response.UserId);
			return request;
		}

		public JsonPatchDocument<ApiMessengerRequestModel> CreatePatch(ApiMessengerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiMessengerRequestModel>();
			patch.Replace(x => x.Date, model.Date);
			patch.Replace(x => x.FromUserId, model.FromUserId);
			patch.Replace(x => x.MessageId, model.MessageId);
			patch.Replace(x => x.Time, model.Time);
			patch.Replace(x => x.ToUserId, model.ToUserId);
			patch.Replace(x => x.UserId, model.UserId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>5af802de5f8c287ae34ed372899dfc23</Hash>
</Codenesium>*/
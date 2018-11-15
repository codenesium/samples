using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractApiMessengerServerModelMapper
	{
		public virtual ApiMessengerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiMessengerServerRequestModel request)
		{
			var response = new ApiMessengerServerResponseModel();
			response.SetProperties(id,
			                       request.Date,
			                       request.FromUserId,
			                       request.MessageId,
			                       request.Time,
			                       request.ToUserId,
			                       request.UserId);
			return response;
		}

		public virtual ApiMessengerServerRequestModel MapServerResponseToRequest(
			ApiMessengerServerResponseModel response)
		{
			var request = new ApiMessengerServerRequestModel();
			request.SetProperties(
				response.Date,
				response.FromUserId,
				response.MessageId,
				response.Time,
				response.ToUserId,
				response.UserId);
			return request;
		}

		public virtual ApiMessengerClientRequestModel MapServerResponseToClientRequest(
			ApiMessengerServerResponseModel response)
		{
			var request = new ApiMessengerClientRequestModel();
			request.SetProperties(
				response.Date,
				response.FromUserId,
				response.MessageId,
				response.Time,
				response.ToUserId,
				response.UserId);
			return request;
		}

		public JsonPatchDocument<ApiMessengerServerRequestModel> CreatePatch(ApiMessengerServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiMessengerServerRequestModel>();
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
    <Hash>fa94d8e624b63435f81b789475c28fc1</Hash>
</Codenesium>*/
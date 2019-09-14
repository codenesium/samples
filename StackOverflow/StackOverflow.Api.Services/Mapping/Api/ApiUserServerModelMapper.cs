using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiUserServerModelMapper : IApiUserServerModelMapper
	{
		public virtual ApiUserServerResponseModel MapServerRequestToResponse(
			int id,
			ApiUserServerRequestModel request)
		{
			var response = new ApiUserServerResponseModel();
			response.SetProperties(id,
			                       request.AboutMe,
			                       request.AccountId,
			                       request.Age,
			                       request.CreationDate,
			                       request.DisplayName,
			                       request.DownVote,
			                       request.EmailHash,
			                       request.LastAccessDate,
			                       request.Location,
			                       request.Reputation,
			                       request.UpVote,
			                       request.View,
			                       request.WebsiteUrl);
			return response;
		}

		public virtual ApiUserServerRequestModel MapServerResponseToRequest(
			ApiUserServerResponseModel response)
		{
			var request = new ApiUserServerRequestModel();
			request.SetProperties(
				response.AboutMe,
				response.AccountId,
				response.Age,
				response.CreationDate,
				response.DisplayName,
				response.DownVote,
				response.EmailHash,
				response.LastAccessDate,
				response.Location,
				response.Reputation,
				response.UpVote,
				response.View,
				response.WebsiteUrl);
			return request;
		}

		public virtual ApiUserClientRequestModel MapServerResponseToClientRequest(
			ApiUserServerResponseModel response)
		{
			var request = new ApiUserClientRequestModel();
			request.SetProperties(
				response.AboutMe,
				response.AccountId,
				response.Age,
				response.CreationDate,
				response.DisplayName,
				response.DownVote,
				response.EmailHash,
				response.LastAccessDate,
				response.Location,
				response.Reputation,
				response.UpVote,
				response.View,
				response.WebsiteUrl);
			return request;
		}

		public JsonPatchDocument<ApiUserServerRequestModel> CreatePatch(ApiUserServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUserServerRequestModel>();
			patch.Replace(x => x.AboutMe, model.AboutMe);
			patch.Replace(x => x.AccountId, model.AccountId);
			patch.Replace(x => x.Age, model.Age);
			patch.Replace(x => x.CreationDate, model.CreationDate);
			patch.Replace(x => x.DisplayName, model.DisplayName);
			patch.Replace(x => x.DownVote, model.DownVote);
			patch.Replace(x => x.EmailHash, model.EmailHash);
			patch.Replace(x => x.LastAccessDate, model.LastAccessDate);
			patch.Replace(x => x.Location, model.Location);
			patch.Replace(x => x.Reputation, model.Reputation);
			patch.Replace(x => x.UpVote, model.UpVote);
			patch.Replace(x => x.View, model.View);
			patch.Replace(x => x.WebsiteUrl, model.WebsiteUrl);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>be0f9b0b9e4f29eac1274fc9efe69412</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
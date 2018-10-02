using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiUserModelMapper
	{
		public virtual ApiUserResponseModel MapRequestToResponse(
			int id,
			ApiUserRequestModel request)
		{
			var response = new ApiUserResponseModel();
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

		public virtual ApiUserRequestModel MapResponseToRequest(
			ApiUserResponseModel response)
		{
			var request = new ApiUserRequestModel();
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

		public JsonPatchDocument<ApiUserRequestModel> CreatePatch(ApiUserRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUserRequestModel>();
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
    <Hash>13a9f09450cd246732c67e2907d3953c</Hash>
</Codenesium>*/
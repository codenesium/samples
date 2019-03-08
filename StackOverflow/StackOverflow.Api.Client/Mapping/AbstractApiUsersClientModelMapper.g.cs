using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiUsersModelMapper
	{
		public virtual ApiUsersClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUsersClientRequestModel request)
		{
			var response = new ApiUsersClientResponseModel();
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

		public virtual ApiUsersClientRequestModel MapClientResponseToRequest(
			ApiUsersClientResponseModel response)
		{
			var request = new ApiUsersClientRequestModel();
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
	}
}

/*<Codenesium>
    <Hash>17fbdcd970cfd7196c0eb60975828965</Hash>
</Codenesium>*/
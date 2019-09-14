using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public class ApiUserModelMapper : IApiUserModelMapper
	{
		public virtual ApiUserClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUserClientRequestModel request)
		{
			var response = new ApiUserClientResponseModel();
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

		public virtual ApiUserClientRequestModel MapClientResponseToRequest(
			ApiUserClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>689ae24b6f022bd5694537af21fa4d4e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
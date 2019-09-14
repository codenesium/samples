using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public class ApiPostModelMapper : IApiPostModelMapper
	{
		public virtual ApiPostClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostClientRequestModel request)
		{
			var response = new ApiPostClientResponseModel();
			response.SetProperties(id,
			                       request.AcceptedAnswerId,
			                       request.AnswerCount,
			                       request.Body,
			                       request.ClosedDate,
			                       request.CommentCount,
			                       request.CommunityOwnedDate,
			                       request.CreationDate,
			                       request.FavoriteCount,
			                       request.LastActivityDate,
			                       request.LastEditDate,
			                       request.LastEditorDisplayName,
			                       request.LastEditorUserId,
			                       request.OwnerUserId,
			                       request.ParentId,
			                       request.PostTypeId,
			                       request.Score,
			                       request.Tag,
			                       request.Title,
			                       request.ViewCount);
			return response;
		}

		public virtual ApiPostClientRequestModel MapClientResponseToRequest(
			ApiPostClientResponseModel response)
		{
			var request = new ApiPostClientRequestModel();
			request.SetProperties(
				response.AcceptedAnswerId,
				response.AnswerCount,
				response.Body,
				response.ClosedDate,
				response.CommentCount,
				response.CommunityOwnedDate,
				response.CreationDate,
				response.FavoriteCount,
				response.LastActivityDate,
				response.LastEditDate,
				response.LastEditorDisplayName,
				response.LastEditorUserId,
				response.OwnerUserId,
				response.ParentId,
				response.PostTypeId,
				response.Score,
				response.Tag,
				response.Title,
				response.ViewCount);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>10d9f549ae4abbc7996c73351d5e5178</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
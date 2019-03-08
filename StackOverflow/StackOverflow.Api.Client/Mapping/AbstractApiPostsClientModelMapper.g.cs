using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiPostsModelMapper
	{
		public virtual ApiPostsClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostsClientRequestModel request)
		{
			var response = new ApiPostsClientResponseModel();
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

		public virtual ApiPostsClientRequestModel MapClientResponseToRequest(
			ApiPostsClientResponseModel response)
		{
			var request = new ApiPostsClientRequestModel();
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
    <Hash>d74edc8b55c32252143d7bdb71d8312d</Hash>
</Codenesium>*/
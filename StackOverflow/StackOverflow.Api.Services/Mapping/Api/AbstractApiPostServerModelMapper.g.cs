using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiPostServerModelMapper
	{
		public virtual ApiPostServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostServerRequestModel request)
		{
			var response = new ApiPostServerResponseModel();
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

		public virtual ApiPostServerRequestModel MapServerResponseToRequest(
			ApiPostServerResponseModel response)
		{
			var request = new ApiPostServerRequestModel();
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

		public virtual ApiPostClientRequestModel MapServerResponseToClientRequest(
			ApiPostServerResponseModel response)
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

		public JsonPatchDocument<ApiPostServerRequestModel> CreatePatch(ApiPostServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostServerRequestModel>();
			patch.Replace(x => x.AcceptedAnswerId, model.AcceptedAnswerId);
			patch.Replace(x => x.AnswerCount, model.AnswerCount);
			patch.Replace(x => x.Body, model.Body);
			patch.Replace(x => x.ClosedDate, model.ClosedDate);
			patch.Replace(x => x.CommentCount, model.CommentCount);
			patch.Replace(x => x.CommunityOwnedDate, model.CommunityOwnedDate);
			patch.Replace(x => x.CreationDate, model.CreationDate);
			patch.Replace(x => x.FavoriteCount, model.FavoriteCount);
			patch.Replace(x => x.LastActivityDate, model.LastActivityDate);
			patch.Replace(x => x.LastEditDate, model.LastEditDate);
			patch.Replace(x => x.LastEditorDisplayName, model.LastEditorDisplayName);
			patch.Replace(x => x.LastEditorUserId, model.LastEditorUserId);
			patch.Replace(x => x.OwnerUserId, model.OwnerUserId);
			patch.Replace(x => x.ParentId, model.ParentId);
			patch.Replace(x => x.PostTypeId, model.PostTypeId);
			patch.Replace(x => x.Score, model.Score);
			patch.Replace(x => x.Tag, model.Tag);
			patch.Replace(x => x.Title, model.Title);
			patch.Replace(x => x.ViewCount, model.ViewCount);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>fd1af879cfe4667b968d6bf5807db104</Hash>
</Codenesium>*/
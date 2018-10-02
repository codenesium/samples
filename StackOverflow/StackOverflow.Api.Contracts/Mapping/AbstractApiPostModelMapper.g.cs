using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiPostModelMapper
	{
		public virtual ApiPostResponseModel MapRequestToResponse(
			int id,
			ApiPostRequestModel request)
		{
			var response = new ApiPostResponseModel();
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

		public virtual ApiPostRequestModel MapResponseToRequest(
			ApiPostResponseModel response)
		{
			var request = new ApiPostRequestModel();
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

		public JsonPatchDocument<ApiPostRequestModel> CreatePatch(ApiPostRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostRequestModel>();
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
    <Hash>54e58d1a76bb5481b8136a85b578a053</Hash>
</Codenesium>*/
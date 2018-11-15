using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiPostHistoryServerModelMapper
	{
		public virtual ApiPostHistoryServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostHistoryServerRequestModel request)
		{
			var response = new ApiPostHistoryServerResponseModel();
			response.SetProperties(id,
			                       request.Comment,
			                       request.CreationDate,
			                       request.PostHistoryTypeId,
			                       request.PostId,
			                       request.RevisionGUID,
			                       request.Text,
			                       request.UserDisplayName,
			                       request.UserId);
			return response;
		}

		public virtual ApiPostHistoryServerRequestModel MapServerResponseToRequest(
			ApiPostHistoryServerResponseModel response)
		{
			var request = new ApiPostHistoryServerRequestModel();
			request.SetProperties(
				response.Comment,
				response.CreationDate,
				response.PostHistoryTypeId,
				response.PostId,
				response.RevisionGUID,
				response.Text,
				response.UserDisplayName,
				response.UserId);
			return request;
		}

		public virtual ApiPostHistoryClientRequestModel MapServerResponseToClientRequest(
			ApiPostHistoryServerResponseModel response)
		{
			var request = new ApiPostHistoryClientRequestModel();
			request.SetProperties(
				response.Comment,
				response.CreationDate,
				response.PostHistoryTypeId,
				response.PostId,
				response.RevisionGUID,
				response.Text,
				response.UserDisplayName,
				response.UserId);
			return request;
		}

		public JsonPatchDocument<ApiPostHistoryServerRequestModel> CreatePatch(ApiPostHistoryServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostHistoryServerRequestModel>();
			patch.Replace(x => x.Comment, model.Comment);
			patch.Replace(x => x.CreationDate, model.CreationDate);
			patch.Replace(x => x.PostHistoryTypeId, model.PostHistoryTypeId);
			patch.Replace(x => x.PostId, model.PostId);
			patch.Replace(x => x.RevisionGUID, model.RevisionGUID);
			patch.Replace(x => x.Text, model.Text);
			patch.Replace(x => x.UserDisplayName, model.UserDisplayName);
			patch.Replace(x => x.UserId, model.UserId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>874c9b04aa7d2be5760179cc37e53aa0</Hash>
</Codenesium>*/
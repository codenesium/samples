using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiPostHistoryModelMapper
	{
		public virtual ApiPostHistoryResponseModel MapRequestToResponse(
			int id,
			ApiPostHistoryRequestModel request)
		{
			var response = new ApiPostHistoryResponseModel();
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

		public virtual ApiPostHistoryRequestModel MapResponseToRequest(
			ApiPostHistoryResponseModel response)
		{
			var request = new ApiPostHistoryRequestModel();
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

		public JsonPatchDocument<ApiPostHistoryRequestModel> CreatePatch(ApiPostHistoryRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostHistoryRequestModel>();
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
    <Hash>70c322d55818e4ba7adc103de3fb0308</Hash>
</Codenesium>*/
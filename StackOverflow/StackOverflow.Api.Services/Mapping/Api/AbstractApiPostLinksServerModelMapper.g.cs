using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiPostLinksServerModelMapper
	{
		public virtual ApiPostLinksServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostLinksServerRequestModel request)
		{
			var response = new ApiPostLinksServerResponseModel();
			response.SetProperties(id,
			                       request.CreationDate,
			                       request.LinkTypeId,
			                       request.PostId,
			                       request.RelatedPostId);
			return response;
		}

		public virtual ApiPostLinksServerRequestModel MapServerResponseToRequest(
			ApiPostLinksServerResponseModel response)
		{
			var request = new ApiPostLinksServerRequestModel();
			request.SetProperties(
				response.CreationDate,
				response.LinkTypeId,
				response.PostId,
				response.RelatedPostId);
			return request;
		}

		public virtual ApiPostLinksClientRequestModel MapServerResponseToClientRequest(
			ApiPostLinksServerResponseModel response)
		{
			var request = new ApiPostLinksClientRequestModel();
			request.SetProperties(
				response.CreationDate,
				response.LinkTypeId,
				response.PostId,
				response.RelatedPostId);
			return request;
		}

		public JsonPatchDocument<ApiPostLinksServerRequestModel> CreatePatch(ApiPostLinksServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostLinksServerRequestModel>();
			patch.Replace(x => x.CreationDate, model.CreationDate);
			patch.Replace(x => x.LinkTypeId, model.LinkTypeId);
			patch.Replace(x => x.PostId, model.PostId);
			patch.Replace(x => x.RelatedPostId, model.RelatedPostId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ec15392b58ce58a959889c6d64cd54df</Hash>
</Codenesium>*/
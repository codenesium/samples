using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiPostLinkServerModelMapper : IApiPostLinkServerModelMapper
	{
		public virtual ApiPostLinkServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostLinkServerRequestModel request)
		{
			var response = new ApiPostLinkServerResponseModel();
			response.SetProperties(id,
			                       request.CreationDate,
			                       request.LinkTypeId,
			                       request.PostId,
			                       request.RelatedPostId);
			return response;
		}

		public virtual ApiPostLinkServerRequestModel MapServerResponseToRequest(
			ApiPostLinkServerResponseModel response)
		{
			var request = new ApiPostLinkServerRequestModel();
			request.SetProperties(
				response.CreationDate,
				response.LinkTypeId,
				response.PostId,
				response.RelatedPostId);
			return request;
		}

		public virtual ApiPostLinkClientRequestModel MapServerResponseToClientRequest(
			ApiPostLinkServerResponseModel response)
		{
			var request = new ApiPostLinkClientRequestModel();
			request.SetProperties(
				response.CreationDate,
				response.LinkTypeId,
				response.PostId,
				response.RelatedPostId);
			return request;
		}

		public JsonPatchDocument<ApiPostLinkServerRequestModel> CreatePatch(ApiPostLinkServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostLinkServerRequestModel>();
			patch.Replace(x => x.CreationDate, model.CreationDate);
			patch.Replace(x => x.LinkTypeId, model.LinkTypeId);
			patch.Replace(x => x.PostId, model.PostId);
			patch.Replace(x => x.RelatedPostId, model.RelatedPostId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>44a09104bf87553d0576d64214435405</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
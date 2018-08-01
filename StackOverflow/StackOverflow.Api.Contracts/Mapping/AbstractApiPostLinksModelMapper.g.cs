using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiPostLinksModelMapper
	{
		public virtual ApiPostLinksResponseModel MapRequestToResponse(
			int id,
			ApiPostLinksRequestModel request)
		{
			var response = new ApiPostLinksResponseModel();
			response.SetProperties(id,
			                       request.CreationDate,
			                       request.LinkTypeId,
			                       request.PostId,
			                       request.RelatedPostId);
			return response;
		}

		public virtual ApiPostLinksRequestModel MapResponseToRequest(
			ApiPostLinksResponseModel response)
		{
			var request = new ApiPostLinksRequestModel();
			request.SetProperties(
				response.CreationDate,
				response.LinkTypeId,
				response.PostId,
				response.RelatedPostId);
			return request;
		}

		public JsonPatchDocument<ApiPostLinksRequestModel> CreatePatch(ApiPostLinksRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostLinksRequestModel>();
			patch.Replace(x => x.CreationDate, model.CreationDate);
			patch.Replace(x => x.LinkTypeId, model.LinkTypeId);
			patch.Replace(x => x.PostId, model.PostId);
			patch.Replace(x => x.RelatedPostId, model.RelatedPostId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>c6437e0ef923413af12d0c8acb27df6d</Hash>
</Codenesium>*/
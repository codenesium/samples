using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiEventRelatedDocumentModelMapper
	{
		public virtual ApiEventRelatedDocumentResponseModel MapRequestToResponse(
			int id,
			ApiEventRelatedDocumentRequestModel request)
		{
			var response = new ApiEventRelatedDocumentResponseModel();
			response.SetProperties(id,
			                       request.EventId,
			                       request.RelatedDocumentId);
			return response;
		}

		public virtual ApiEventRelatedDocumentRequestModel MapResponseToRequest(
			ApiEventRelatedDocumentResponseModel response)
		{
			var request = new ApiEventRelatedDocumentRequestModel();
			request.SetProperties(
				response.EventId,
				response.RelatedDocumentId);
			return request;
		}

		public JsonPatchDocument<ApiEventRelatedDocumentRequestModel> CreatePatch(ApiEventRelatedDocumentRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventRelatedDocumentRequestModel>();
			patch.Replace(x => x.EventId, model.EventId);
			patch.Replace(x => x.RelatedDocumentId, model.RelatedDocumentId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>cc8ab0e5411d201c60f450d3712023a3</Hash>
</Codenesium>*/
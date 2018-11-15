using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiIllustrationServerModelMapper
	{
		public virtual ApiIllustrationServerResponseModel MapServerRequestToResponse(
			int illustrationID,
			ApiIllustrationServerRequestModel request)
		{
			var response = new ApiIllustrationServerResponseModel();
			response.SetProperties(illustrationID,
			                       request.Diagram,
			                       request.ModifiedDate);
			return response;
		}

		public virtual ApiIllustrationServerRequestModel MapServerResponseToRequest(
			ApiIllustrationServerResponseModel response)
		{
			var request = new ApiIllustrationServerRequestModel();
			request.SetProperties(
				response.Diagram,
				response.ModifiedDate);
			return request;
		}

		public virtual ApiIllustrationClientRequestModel MapServerResponseToClientRequest(
			ApiIllustrationServerResponseModel response)
		{
			var request = new ApiIllustrationClientRequestModel();
			request.SetProperties(
				response.Diagram,
				response.ModifiedDate);
			return request;
		}

		public JsonPatchDocument<ApiIllustrationServerRequestModel> CreatePatch(ApiIllustrationServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiIllustrationServerRequestModel>();
			patch.Replace(x => x.Diagram, model.Diagram);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>656de7a75cc010c131f880abe77df671</Hash>
</Codenesium>*/
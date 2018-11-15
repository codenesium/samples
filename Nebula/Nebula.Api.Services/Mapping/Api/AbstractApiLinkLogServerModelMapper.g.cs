using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiLinkLogServerModelMapper
	{
		public virtual ApiLinkLogServerResponseModel MapServerRequestToResponse(
			int id,
			ApiLinkLogServerRequestModel request)
		{
			var response = new ApiLinkLogServerResponseModel();
			response.SetProperties(id,
			                       request.DateEntered,
			                       request.LinkId,
			                       request.Log);
			return response;
		}

		public virtual ApiLinkLogServerRequestModel MapServerResponseToRequest(
			ApiLinkLogServerResponseModel response)
		{
			var request = new ApiLinkLogServerRequestModel();
			request.SetProperties(
				response.DateEntered,
				response.LinkId,
				response.Log);
			return request;
		}

		public virtual ApiLinkLogClientRequestModel MapServerResponseToClientRequest(
			ApiLinkLogServerResponseModel response)
		{
			var request = new ApiLinkLogClientRequestModel();
			request.SetProperties(
				response.DateEntered,
				response.LinkId,
				response.Log);
			return request;
		}

		public JsonPatchDocument<ApiLinkLogServerRequestModel> CreatePatch(ApiLinkLogServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLinkLogServerRequestModel>();
			patch.Replace(x => x.DateEntered, model.DateEntered);
			patch.Replace(x => x.LinkId, model.LinkId);
			patch.Replace(x => x.Log, model.Log);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>2a334726a66ff698cfc65e03372c10d3</Hash>
</Codenesium>*/
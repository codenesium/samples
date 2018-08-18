using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public abstract class AbstractApiLinkLogModelMapper
	{
		public virtual ApiLinkLogResponseModel MapRequestToResponse(
			int id,
			ApiLinkLogRequestModel request)
		{
			var response = new ApiLinkLogResponseModel();
			response.SetProperties(id,
			                       request.DateEntered,
			                       request.LinkId,
			                       request.Log);
			return response;
		}

		public virtual ApiLinkLogRequestModel MapResponseToRequest(
			ApiLinkLogResponseModel response)
		{
			var request = new ApiLinkLogRequestModel();
			request.SetProperties(
				response.DateEntered,
				response.LinkId,
				response.Log);
			return request;
		}

		public JsonPatchDocument<ApiLinkLogRequestModel> CreatePatch(ApiLinkLogRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLinkLogRequestModel>();
			patch.Replace(x => x.DateEntered, model.DateEntered);
			patch.Replace(x => x.LinkId, model.LinkId);
			patch.Replace(x => x.Log, model.Log);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e219db12932544861f43ef9a08d296cc</Hash>
</Codenesium>*/
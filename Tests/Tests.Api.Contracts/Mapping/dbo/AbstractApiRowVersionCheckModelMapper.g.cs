using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public abstract class AbstractApiRowVersionCheckModelMapper
	{
		public virtual ApiRowVersionCheckResponseModel MapRequestToResponse(
			int id,
			ApiRowVersionCheckRequestModel request)
		{
			var response = new ApiRowVersionCheckResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.RowVersion);
			return response;
		}

		public virtual ApiRowVersionCheckRequestModel MapResponseToRequest(
			ApiRowVersionCheckResponseModel response)
		{
			var request = new ApiRowVersionCheckRequestModel();
			request.SetProperties(
				response.Name,
				response.RowVersion);
			return request;
		}

		public JsonPatchDocument<ApiRowVersionCheckRequestModel> CreatePatch(ApiRowVersionCheckRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiRowVersionCheckRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.RowVersion, model.RowVersion);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>272da93b0ca8b871da9b4609c8b796bd</Hash>
</Codenesium>*/
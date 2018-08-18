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
    <Hash>b66a77d8e1ebf9a54189c5c98c09914b</Hash>
</Codenesium>*/
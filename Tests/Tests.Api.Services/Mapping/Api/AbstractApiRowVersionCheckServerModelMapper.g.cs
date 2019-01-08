using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiRowVersionCheckServerModelMapper
	{
		public virtual ApiRowVersionCheckServerResponseModel MapServerRequestToResponse(
			int id,
			ApiRowVersionCheckServerRequestModel request)
		{
			var response = new ApiRowVersionCheckServerResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.RowVersion);
			return response;
		}

		public virtual ApiRowVersionCheckServerRequestModel MapServerResponseToRequest(
			ApiRowVersionCheckServerResponseModel response)
		{
			var request = new ApiRowVersionCheckServerRequestModel();
			request.SetProperties(
				response.Name,
				response.RowVersion);
			return request;
		}

		public virtual ApiRowVersionCheckClientRequestModel MapServerResponseToClientRequest(
			ApiRowVersionCheckServerResponseModel response)
		{
			var request = new ApiRowVersionCheckClientRequestModel();
			request.SetProperties(
				response.Name,
				response.RowVersion);
			return request;
		}

		public JsonPatchDocument<ApiRowVersionCheckServerRequestModel> CreatePatch(ApiRowVersionCheckServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiRowVersionCheckServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.RowVersion, model.RowVersion);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d495983e0cdfdded97a753422c846cfd</Hash>
</Codenesium>*/
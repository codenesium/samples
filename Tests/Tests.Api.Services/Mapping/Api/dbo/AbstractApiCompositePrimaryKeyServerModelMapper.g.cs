using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiCompositePrimaryKeyServerModelMapper
	{
		public virtual ApiCompositePrimaryKeyServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCompositePrimaryKeyServerRequestModel request)
		{
			var response = new ApiCompositePrimaryKeyServerResponseModel();
			response.SetProperties(id,
			                       request.Id2);
			return response;
		}

		public virtual ApiCompositePrimaryKeyServerRequestModel MapServerResponseToRequest(
			ApiCompositePrimaryKeyServerResponseModel response)
		{
			var request = new ApiCompositePrimaryKeyServerRequestModel();
			request.SetProperties(
				response.Id2);
			return request;
		}

		public virtual ApiCompositePrimaryKeyClientRequestModel MapServerResponseToClientRequest(
			ApiCompositePrimaryKeyServerResponseModel response)
		{
			var request = new ApiCompositePrimaryKeyClientRequestModel();
			request.SetProperties(
				response.Id2);
			return request;
		}

		public JsonPatchDocument<ApiCompositePrimaryKeyServerRequestModel> CreatePatch(ApiCompositePrimaryKeyServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCompositePrimaryKeyServerRequestModel>();
			patch.Replace(x => x.Id2, model.Id2);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>baa5574f1316d5f1c52d393860a1117f</Hash>
</Codenesium>*/
using ESPIOTNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractApiEfmigrationshistoryServerModelMapper
	{
		public virtual ApiEfmigrationshistoryServerResponseModel MapServerRequestToResponse(
			string migrationId,
			ApiEfmigrationshistoryServerRequestModel request)
		{
			var response = new ApiEfmigrationshistoryServerResponseModel();
			response.SetProperties(migrationId,
			                       request.ProductVersion);
			return response;
		}

		public virtual ApiEfmigrationshistoryServerRequestModel MapServerResponseToRequest(
			ApiEfmigrationshistoryServerResponseModel response)
		{
			var request = new ApiEfmigrationshistoryServerRequestModel();
			request.SetProperties(
				response.ProductVersion);
			return request;
		}

		public virtual ApiEfmigrationshistoryClientRequestModel MapServerResponseToClientRequest(
			ApiEfmigrationshistoryServerResponseModel response)
		{
			var request = new ApiEfmigrationshistoryClientRequestModel();
			request.SetProperties(
				response.ProductVersion);
			return request;
		}

		public JsonPatchDocument<ApiEfmigrationshistoryServerRequestModel> CreatePatch(ApiEfmigrationshistoryServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEfmigrationshistoryServerRequestModel>();
			patch.Replace(x => x.ProductVersion, model.ProductVersion);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>c4da588727977163cfcf304797f7b9da</Hash>
</Codenesium>*/
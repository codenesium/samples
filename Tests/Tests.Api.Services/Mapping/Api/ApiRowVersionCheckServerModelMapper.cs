using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public class ApiRowVersionCheckServerModelMapper : IApiRowVersionCheckServerModelMapper
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
    <Hash>81a2e84df789643cf45feeba1e5b439e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
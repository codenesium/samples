using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiUnitDispositionServerModelMapper : IApiUnitDispositionServerModelMapper
	{
		public virtual ApiUnitDispositionServerResponseModel MapServerRequestToResponse(
			int id,
			ApiUnitDispositionServerRequestModel request)
		{
			var response = new ApiUnitDispositionServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiUnitDispositionServerRequestModel MapServerResponseToRequest(
			ApiUnitDispositionServerResponseModel response)
		{
			var request = new ApiUnitDispositionServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiUnitDispositionClientRequestModel MapServerResponseToClientRequest(
			ApiUnitDispositionServerResponseModel response)
		{
			var request = new ApiUnitDispositionClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiUnitDispositionServerRequestModel> CreatePatch(ApiUnitDispositionServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUnitDispositionServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9a9ed751d7f3f8723167d8eee4165a2d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
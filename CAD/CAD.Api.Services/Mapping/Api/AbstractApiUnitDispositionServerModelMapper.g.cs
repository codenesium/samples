using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiUnitDispositionServerModelMapper
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
    <Hash>285350324530623f11be7713d434c4dc</Hash>
</Codenesium>*/
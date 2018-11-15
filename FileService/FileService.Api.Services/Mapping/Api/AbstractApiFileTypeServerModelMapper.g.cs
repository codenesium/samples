using FileServiceNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractApiFileTypeServerModelMapper
	{
		public virtual ApiFileTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiFileTypeServerRequestModel request)
		{
			var response = new ApiFileTypeServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiFileTypeServerRequestModel MapServerResponseToRequest(
			ApiFileTypeServerResponseModel response)
		{
			var request = new ApiFileTypeServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiFileTypeClientRequestModel MapServerResponseToClientRequest(
			ApiFileTypeServerResponseModel response)
		{
			var request = new ApiFileTypeClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiFileTypeServerRequestModel> CreatePatch(ApiFileTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiFileTypeServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>35b8ac8274939257ad16109329c47c86</Hash>
</Codenesium>*/
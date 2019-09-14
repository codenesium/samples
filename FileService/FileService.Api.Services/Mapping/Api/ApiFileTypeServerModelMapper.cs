using FileServiceNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public class ApiFileTypeServerModelMapper : IApiFileTypeServerModelMapper
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
    <Hash>47645670b0926f4bda5d87b9687b24a1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
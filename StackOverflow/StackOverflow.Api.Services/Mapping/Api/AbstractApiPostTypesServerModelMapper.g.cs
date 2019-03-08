using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiPostTypesServerModelMapper
	{
		public virtual ApiPostTypesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostTypesServerRequestModel request)
		{
			var response = new ApiPostTypesServerResponseModel();
			response.SetProperties(id,
			                       request.RwType);
			return response;
		}

		public virtual ApiPostTypesServerRequestModel MapServerResponseToRequest(
			ApiPostTypesServerResponseModel response)
		{
			var request = new ApiPostTypesServerRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public virtual ApiPostTypesClientRequestModel MapServerResponseToClientRequest(
			ApiPostTypesServerResponseModel response)
		{
			var request = new ApiPostTypesClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}

		public JsonPatchDocument<ApiPostTypesServerRequestModel> CreatePatch(ApiPostTypesServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostTypesServerRequestModel>();
			patch.Replace(x => x.RwType, model.RwType);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d573e086e55b2eae03ec2dd4e880b8ba</Hash>
</Codenesium>*/
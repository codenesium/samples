using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiPersonRefServerModelMapper
	{
		public virtual ApiPersonRefServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPersonRefServerRequestModel request)
		{
			var response = new ApiPersonRefServerResponseModel();
			response.SetProperties(id,
			                       request.PersonAId,
			                       request.PersonBId);
			return response;
		}

		public virtual ApiPersonRefServerRequestModel MapServerResponseToRequest(
			ApiPersonRefServerResponseModel response)
		{
			var request = new ApiPersonRefServerRequestModel();
			request.SetProperties(
				response.PersonAId,
				response.PersonBId);
			return request;
		}

		public virtual ApiPersonRefClientRequestModel MapServerResponseToClientRequest(
			ApiPersonRefServerResponseModel response)
		{
			var request = new ApiPersonRefClientRequestModel();
			request.SetProperties(
				response.PersonAId,
				response.PersonBId);
			return request;
		}

		public JsonPatchDocument<ApiPersonRefServerRequestModel> CreatePatch(ApiPersonRefServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPersonRefServerRequestModel>();
			patch.Replace(x => x.PersonAId, model.PersonAId);
			patch.Replace(x => x.PersonBId, model.PersonBId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>be77404ce37d6c8be9a9b30091f4dd1c</Hash>
</Codenesium>*/
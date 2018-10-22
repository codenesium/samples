using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiUserModelMapper
	{
		public virtual ApiUserResponseModel MapRequestToResponse(
			int id,
			ApiUserRequestModel request)
		{
			var response = new ApiUserResponseModel();
			response.SetProperties(id,
			                       request.Password,
			                       request.Username);
			return response;
		}

		public virtual ApiUserRequestModel MapResponseToRequest(
			ApiUserResponseModel response)
		{
			var request = new ApiUserRequestModel();
			request.SetProperties(
				response.Password,
				response.Username);
			return request;
		}

		public JsonPatchDocument<ApiUserRequestModel> CreatePatch(ApiUserRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUserRequestModel>();
			patch.Replace(x => x.Password, model.Password);
			patch.Replace(x => x.Username, model.Username);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d8ce7b02fc1f5ee980c41cd68eeba1b5</Hash>
</Codenesium>*/
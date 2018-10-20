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
			                       request.Username,
			                       request.IsDeleted);
			return response;
		}

		public virtual ApiUserRequestModel MapResponseToRequest(
			ApiUserResponseModel response)
		{
			var request = new ApiUserRequestModel();
			request.SetProperties(
				response.Password,
				response.Username,
				response.IsDeleted);
			return request;
		}

		public JsonPatchDocument<ApiUserRequestModel> CreatePatch(ApiUserRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUserRequestModel>();
			patch.Replace(x => x.Password, model.Password);
			patch.Replace(x => x.Username, model.Username);
			patch.Replace(x => x.IsDeleted, model.IsDeleted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>05e88c3bebfa9650441d628c8c0d3799</Hash>
</Codenesium>*/
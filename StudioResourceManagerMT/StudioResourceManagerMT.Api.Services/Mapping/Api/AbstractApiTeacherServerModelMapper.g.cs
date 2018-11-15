using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiTeacherServerModelMapper
	{
		public virtual ApiTeacherServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTeacherServerRequestModel request)
		{
			var response = new ApiTeacherServerResponseModel();
			response.SetProperties(id,
			                       request.Birthday,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Phone,
			                       request.UserId);
			return response;
		}

		public virtual ApiTeacherServerRequestModel MapServerResponseToRequest(
			ApiTeacherServerResponseModel response)
		{
			var request = new ApiTeacherServerRequestModel();
			request.SetProperties(
				response.Birthday,
				response.Email,
				response.FirstName,
				response.LastName,
				response.Phone,
				response.UserId);
			return request;
		}

		public virtual ApiTeacherClientRequestModel MapServerResponseToClientRequest(
			ApiTeacherServerResponseModel response)
		{
			var request = new ApiTeacherClientRequestModel();
			request.SetProperties(
				response.Birthday,
				response.Email,
				response.FirstName,
				response.LastName,
				response.Phone,
				response.UserId);
			return request;
		}

		public JsonPatchDocument<ApiTeacherServerRequestModel> CreatePatch(ApiTeacherServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeacherServerRequestModel>();
			patch.Replace(x => x.Birthday, model.Birthday);
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.Phone, model.Phone);
			patch.Replace(x => x.UserId, model.UserId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>98af2976b8d9f2d0ac943b79d33c945e</Hash>
</Codenesium>*/
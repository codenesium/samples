using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiEventTeacherServerModelMapper
	{
		public virtual ApiEventTeacherServerResponseModel MapServerRequestToResponse(
			int eventId,
			ApiEventTeacherServerRequestModel request)
		{
			var response = new ApiEventTeacherServerResponseModel();
			response.SetProperties(eventId,
			                       request.TeacherId);
			return response;
		}

		public virtual ApiEventTeacherServerRequestModel MapServerResponseToRequest(
			ApiEventTeacherServerResponseModel response)
		{
			var request = new ApiEventTeacherServerRequestModel();
			request.SetProperties(
				response.TeacherId);
			return request;
		}

		public virtual ApiEventTeacherClientRequestModel MapServerResponseToClientRequest(
			ApiEventTeacherServerResponseModel response)
		{
			var request = new ApiEventTeacherClientRequestModel();
			request.SetProperties(
				response.TeacherId);
			return request;
		}

		public JsonPatchDocument<ApiEventTeacherServerRequestModel> CreatePatch(ApiEventTeacherServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventTeacherServerRequestModel>();
			patch.Replace(x => x.TeacherId, model.TeacherId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>fb3482159e88aadcb5bbe0bdd942c450</Hash>
</Codenesium>*/
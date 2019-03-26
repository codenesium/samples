using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiEventTeacherServerModelMapper
	{
		public virtual ApiEventTeacherServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventTeacherServerRequestModel request)
		{
			var response = new ApiEventTeacherServerResponseModel();
			response.SetProperties(id,
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
    <Hash>36247fe858f70941a3f1c8a6bc17b25d</Hash>
</Codenesium>*/
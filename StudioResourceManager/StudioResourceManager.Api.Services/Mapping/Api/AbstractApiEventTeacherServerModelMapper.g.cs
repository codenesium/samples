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
			                       request.EventId,
			                       request.TeacherId);
			return response;
		}

		public virtual ApiEventTeacherServerRequestModel MapServerResponseToRequest(
			ApiEventTeacherServerResponseModel response)
		{
			var request = new ApiEventTeacherServerRequestModel();
			request.SetProperties(
				response.EventId,
				response.TeacherId);
			return request;
		}

		public virtual ApiEventTeacherClientRequestModel MapServerResponseToClientRequest(
			ApiEventTeacherServerResponseModel response)
		{
			var request = new ApiEventTeacherClientRequestModel();
			request.SetProperties(
				response.EventId,
				response.TeacherId);
			return request;
		}

		public JsonPatchDocument<ApiEventTeacherServerRequestModel> CreatePatch(ApiEventTeacherServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventTeacherServerRequestModel>();
			patch.Replace(x => x.EventId, model.EventId);
			patch.Replace(x => x.TeacherId, model.TeacherId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>450c1361f8c677995715874b829cd89b</Hash>
</Codenesium>*/
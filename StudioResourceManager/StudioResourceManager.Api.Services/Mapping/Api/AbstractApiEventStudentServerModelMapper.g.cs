using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiEventStudentServerModelMapper
	{
		public virtual ApiEventStudentServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventStudentServerRequestModel request)
		{
			var response = new ApiEventStudentServerResponseModel();
			response.SetProperties(id,
			                       request.EventId,
			                       request.StudentId);
			return response;
		}

		public virtual ApiEventStudentServerRequestModel MapServerResponseToRequest(
			ApiEventStudentServerResponseModel response)
		{
			var request = new ApiEventStudentServerRequestModel();
			request.SetProperties(
				response.EventId,
				response.StudentId);
			return request;
		}

		public virtual ApiEventStudentClientRequestModel MapServerResponseToClientRequest(
			ApiEventStudentServerResponseModel response)
		{
			var request = new ApiEventStudentClientRequestModel();
			request.SetProperties(
				response.EventId,
				response.StudentId);
			return request;
		}

		public JsonPatchDocument<ApiEventStudentServerRequestModel> CreatePatch(ApiEventStudentServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventStudentServerRequestModel>();
			patch.Replace(x => x.EventId, model.EventId);
			patch.Replace(x => x.StudentId, model.StudentId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>34f7273aa1a78d6201f813b35e606e43</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiEventStudentServerModelMapper
	{
		public virtual ApiEventStudentServerResponseModel MapServerRequestToResponse(
			int eventId,
			ApiEventStudentServerRequestModel request)
		{
			var response = new ApiEventStudentServerResponseModel();
			response.SetProperties(eventId,
			                       request.StudentId);
			return response;
		}

		public virtual ApiEventStudentServerRequestModel MapServerResponseToRequest(
			ApiEventStudentServerResponseModel response)
		{
			var request = new ApiEventStudentServerRequestModel();
			request.SetProperties(
				response.StudentId);
			return request;
		}

		public virtual ApiEventStudentClientRequestModel MapServerResponseToClientRequest(
			ApiEventStudentServerResponseModel response)
		{
			var request = new ApiEventStudentClientRequestModel();
			request.SetProperties(
				response.StudentId);
			return request;
		}

		public JsonPatchDocument<ApiEventStudentServerRequestModel> CreatePatch(ApiEventStudentServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventStudentServerRequestModel>();
			patch.Replace(x => x.StudentId, model.StudentId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>4ba73b6bc5f951899ff1b11dee0e8675</Hash>
</Codenesium>*/
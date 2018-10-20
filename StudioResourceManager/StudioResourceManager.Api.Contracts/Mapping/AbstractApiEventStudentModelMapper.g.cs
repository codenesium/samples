using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiEventStudentModelMapper
	{
		public virtual ApiEventStudentResponseModel MapRequestToResponse(
			int eventId,
			ApiEventStudentRequestModel request)
		{
			var response = new ApiEventStudentResponseModel();
			response.SetProperties(eventId,
			                       request.StudentId,
			                       request.IsDeleted);
			return response;
		}

		public virtual ApiEventStudentRequestModel MapResponseToRequest(
			ApiEventStudentResponseModel response)
		{
			var request = new ApiEventStudentRequestModel();
			request.SetProperties(
				response.StudentId,
				response.IsDeleted);
			return request;
		}

		public JsonPatchDocument<ApiEventStudentRequestModel> CreatePatch(ApiEventStudentRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventStudentRequestModel>();
			patch.Replace(x => x.StudentId, model.StudentId);
			patch.Replace(x => x.IsDeleted, model.IsDeleted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>dd994ecf2cb3638b8c9dc52306c625c9</Hash>
</Codenesium>*/
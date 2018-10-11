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
			                       request.StudentId);
			return response;
		}

		public virtual ApiEventStudentRequestModel MapResponseToRequest(
			ApiEventStudentResponseModel response)
		{
			var request = new ApiEventStudentRequestModel();
			request.SetProperties(
				response.StudentId);
			return request;
		}

		public JsonPatchDocument<ApiEventStudentRequestModel> CreatePatch(ApiEventStudentRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventStudentRequestModel>();
			patch.Replace(x => x.StudentId, model.StudentId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7ee5d419bd8d948499cbe3da6e8c7ed8</Hash>
</Codenesium>*/
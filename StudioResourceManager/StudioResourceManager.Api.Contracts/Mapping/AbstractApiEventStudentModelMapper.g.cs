using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiEventStudentModelMapper
	{
		public virtual ApiEventStudentResponseModel MapRequestToResponse(
			int id,
			ApiEventStudentRequestModel request)
		{
			var response = new ApiEventStudentResponseModel();
			response.SetProperties(id,
			                       request.EventId,
			                       request.StudentId);
			return response;
		}

		public virtual ApiEventStudentRequestModel MapResponseToRequest(
			ApiEventStudentResponseModel response)
		{
			var request = new ApiEventStudentRequestModel();
			request.SetProperties(
				response.EventId,
				response.StudentId);
			return request;
		}

		public JsonPatchDocument<ApiEventStudentRequestModel> CreatePatch(ApiEventStudentRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventStudentRequestModel>();
			patch.Replace(x => x.EventId, model.EventId);
			patch.Replace(x => x.StudentId, model.StudentId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7e88de4e39ce22fb78452b97c116db22</Hash>
</Codenesium>*/
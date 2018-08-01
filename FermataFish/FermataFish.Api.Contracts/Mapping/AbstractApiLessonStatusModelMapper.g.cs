using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public abstract class AbstractApiLessonStatusModelMapper
	{
		public virtual ApiLessonStatusResponseModel MapRequestToResponse(
			int id,
			ApiLessonStatusRequestModel request)
		{
			var response = new ApiLessonStatusResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.StudioId);
			return response;
		}

		public virtual ApiLessonStatusRequestModel MapResponseToRequest(
			ApiLessonStatusResponseModel response)
		{
			var request = new ApiLessonStatusRequestModel();
			request.SetProperties(
				response.Name,
				response.StudioId);
			return request;
		}

		public JsonPatchDocument<ApiLessonStatusRequestModel> CreatePatch(ApiLessonStatusRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLessonStatusRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.StudioId, model.StudioId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>0c5e46fc05c30f4f040d75e1e2ff452f</Hash>
</Codenesium>*/
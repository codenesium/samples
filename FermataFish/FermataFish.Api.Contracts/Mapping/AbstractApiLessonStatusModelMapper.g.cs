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
    <Hash>2da81f77fac18a10cc51d91432f7d650</Hash>
</Codenesium>*/
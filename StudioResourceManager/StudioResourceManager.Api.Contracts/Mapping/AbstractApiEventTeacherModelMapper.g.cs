using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiEventTeacherModelMapper
	{
		public virtual ApiEventTeacherResponseModel MapRequestToResponse(
			int eventId,
			ApiEventTeacherRequestModel request)
		{
			var response = new ApiEventTeacherResponseModel();
			response.SetProperties(eventId,
			                       request.TeacherId);
			return response;
		}

		public virtual ApiEventTeacherRequestModel MapResponseToRequest(
			ApiEventTeacherResponseModel response)
		{
			var request = new ApiEventTeacherRequestModel();
			request.SetProperties(
				response.TeacherId);
			return request;
		}

		public JsonPatchDocument<ApiEventTeacherRequestModel> CreatePatch(ApiEventTeacherRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventTeacherRequestModel>();
			patch.Replace(x => x.TeacherId, model.TeacherId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b3f61ce81a69a4bbf1eaf75eefdc1733</Hash>
</Codenesium>*/
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
			                       request.TeacherId,
			                       request.IsDeleted);
			return response;
		}

		public virtual ApiEventTeacherRequestModel MapResponseToRequest(
			ApiEventTeacherResponseModel response)
		{
			var request = new ApiEventTeacherRequestModel();
			request.SetProperties(
				response.TeacherId,
				response.IsDeleted);
			return request;
		}

		public JsonPatchDocument<ApiEventTeacherRequestModel> CreatePatch(ApiEventTeacherRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventTeacherRequestModel>();
			patch.Replace(x => x.TeacherId, model.TeacherId);
			patch.Replace(x => x.IsDeleted, model.IsDeleted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>08c6c2362fd107b91b4febc839331ada</Hash>
</Codenesium>*/
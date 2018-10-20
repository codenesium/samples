using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiRateModelMapper
	{
		public virtual ApiRateResponseModel MapRequestToResponse(
			int id,
			ApiRateRequestModel request)
		{
			var response = new ApiRateResponseModel();
			response.SetProperties(id,
			                       request.AmountPerMinute,
			                       request.TeacherId,
			                       request.TeacherSkillId,
			                       request.IsDeleted);
			return response;
		}

		public virtual ApiRateRequestModel MapResponseToRequest(
			ApiRateResponseModel response)
		{
			var request = new ApiRateRequestModel();
			request.SetProperties(
				response.AmountPerMinute,
				response.TeacherId,
				response.TeacherSkillId,
				response.IsDeleted);
			return request;
		}

		public JsonPatchDocument<ApiRateRequestModel> CreatePatch(ApiRateRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiRateRequestModel>();
			patch.Replace(x => x.AmountPerMinute, model.AmountPerMinute);
			patch.Replace(x => x.TeacherId, model.TeacherId);
			patch.Replace(x => x.TeacherSkillId, model.TeacherSkillId);
			patch.Replace(x => x.IsDeleted, model.IsDeleted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>cd777fce1bef0ee25b73fbf0c0b67974</Hash>
</Codenesium>*/
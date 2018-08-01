using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public abstract class AbstractApiTeacherXTeacherSkillModelMapper
	{
		public virtual ApiTeacherXTeacherSkillResponseModel MapRequestToResponse(
			int id,
			ApiTeacherXTeacherSkillRequestModel request)
		{
			var response = new ApiTeacherXTeacherSkillResponseModel();
			response.SetProperties(id,
			                       request.TeacherId,
			                       request.TeacherSkillId);
			return response;
		}

		public virtual ApiTeacherXTeacherSkillRequestModel MapResponseToRequest(
			ApiTeacherXTeacherSkillResponseModel response)
		{
			var request = new ApiTeacherXTeacherSkillRequestModel();
			request.SetProperties(
				response.TeacherId,
				response.TeacherSkillId);
			return request;
		}

		public JsonPatchDocument<ApiTeacherXTeacherSkillRequestModel> CreatePatch(ApiTeacherXTeacherSkillRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeacherXTeacherSkillRequestModel>();
			patch.Replace(x => x.TeacherId, model.TeacherId);
			patch.Replace(x => x.TeacherSkillId, model.TeacherSkillId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>792530e206f2e72e5f097fc76db05487</Hash>
</Codenesium>*/
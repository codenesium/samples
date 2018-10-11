using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiTeacherTeacherSkillModelMapper
	{
		public virtual ApiTeacherTeacherSkillResponseModel MapRequestToResponse(
			int teacherId,
			ApiTeacherTeacherSkillRequestModel request)
		{
			var response = new ApiTeacherTeacherSkillResponseModel();
			response.SetProperties(teacherId,
			                       request.TeacherSkillId);
			return response;
		}

		public virtual ApiTeacherTeacherSkillRequestModel MapResponseToRequest(
			ApiTeacherTeacherSkillResponseModel response)
		{
			var request = new ApiTeacherTeacherSkillRequestModel();
			request.SetProperties(
				response.TeacherSkillId);
			return request;
		}

		public JsonPatchDocument<ApiTeacherTeacherSkillRequestModel> CreatePatch(ApiTeacherTeacherSkillRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeacherTeacherSkillRequestModel>();
			patch.Replace(x => x.TeacherSkillId, model.TeacherSkillId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>3a287dc3213c528046ea7d48785ec7ba</Hash>
</Codenesium>*/
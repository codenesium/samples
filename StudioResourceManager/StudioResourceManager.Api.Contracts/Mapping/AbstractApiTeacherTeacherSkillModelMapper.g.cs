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
			                       request.TeacherSkillId,
			                       request.IsDeleted);
			return response;
		}

		public virtual ApiTeacherTeacherSkillRequestModel MapResponseToRequest(
			ApiTeacherTeacherSkillResponseModel response)
		{
			var request = new ApiTeacherTeacherSkillRequestModel();
			request.SetProperties(
				response.TeacherSkillId,
				response.IsDeleted);
			return request;
		}

		public JsonPatchDocument<ApiTeacherTeacherSkillRequestModel> CreatePatch(ApiTeacherTeacherSkillRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeacherTeacherSkillRequestModel>();
			patch.Replace(x => x.TeacherSkillId, model.TeacherSkillId);
			patch.Replace(x => x.IsDeleted, model.IsDeleted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b37ecaac1f8e70ca407e4edaecbede5a</Hash>
</Codenesium>*/
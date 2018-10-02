using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiTeacherTeacherSkillModelMapper
	{
		public virtual ApiTeacherTeacherSkillResponseModel MapRequestToResponse(
			int id,
			ApiTeacherTeacherSkillRequestModel request)
		{
			var response = new ApiTeacherTeacherSkillResponseModel();
			response.SetProperties(id,
			                       request.TeacherId,
			                       request.TeacherSkillId);
			return response;
		}

		public virtual ApiTeacherTeacherSkillRequestModel MapResponseToRequest(
			ApiTeacherTeacherSkillResponseModel response)
		{
			var request = new ApiTeacherTeacherSkillRequestModel();
			request.SetProperties(
				response.TeacherId,
				response.TeacherSkillId);
			return request;
		}

		public JsonPatchDocument<ApiTeacherTeacherSkillRequestModel> CreatePatch(ApiTeacherTeacherSkillRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeacherTeacherSkillRequestModel>();
			patch.Replace(x => x.TeacherId, model.TeacherId);
			patch.Replace(x => x.TeacherSkillId, model.TeacherSkillId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8787733424166539b8afd066c1163fd8</Hash>
</Codenesium>*/
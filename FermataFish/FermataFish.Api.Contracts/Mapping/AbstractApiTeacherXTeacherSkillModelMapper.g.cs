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
    <Hash>d787b28370f70e660ebf803cff846b27</Hash>
</Codenesium>*/
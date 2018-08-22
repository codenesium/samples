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
			                       request.TeacherSkillId,
			                       request.StudioId);
			return response;
		}

		public virtual ApiTeacherXTeacherSkillRequestModel MapResponseToRequest(
			ApiTeacherXTeacherSkillResponseModel response)
		{
			var request = new ApiTeacherXTeacherSkillRequestModel();
			request.SetProperties(
				response.TeacherId,
				response.TeacherSkillId,
				response.StudioId);
			return request;
		}

		public JsonPatchDocument<ApiTeacherXTeacherSkillRequestModel> CreatePatch(ApiTeacherXTeacherSkillRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeacherXTeacherSkillRequestModel>();
			patch.Replace(x => x.TeacherId, model.TeacherId);
			patch.Replace(x => x.TeacherSkillId, model.TeacherSkillId);
			patch.Replace(x => x.StudioId, model.StudioId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>c50d6dc332f69c372c658cea50f1139a</Hash>
</Codenesium>*/
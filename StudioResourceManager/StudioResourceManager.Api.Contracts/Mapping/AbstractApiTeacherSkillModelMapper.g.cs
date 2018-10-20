using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiTeacherSkillModelMapper
	{
		public virtual ApiTeacherSkillResponseModel MapRequestToResponse(
			int id,
			ApiTeacherSkillRequestModel request)
		{
			var response = new ApiTeacherSkillResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.IsDeleted);
			return response;
		}

		public virtual ApiTeacherSkillRequestModel MapResponseToRequest(
			ApiTeacherSkillResponseModel response)
		{
			var request = new ApiTeacherSkillRequestModel();
			request.SetProperties(
				response.Name,
				response.IsDeleted);
			return request;
		}

		public JsonPatchDocument<ApiTeacherSkillRequestModel> CreatePatch(ApiTeacherSkillRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeacherSkillRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.IsDeleted, model.IsDeleted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e071260583341f3cb90ef0c9f48400df</Hash>
</Codenesium>*/
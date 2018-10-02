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
			                       request.Name);
			return response;
		}

		public virtual ApiTeacherSkillRequestModel MapResponseToRequest(
			ApiTeacherSkillResponseModel response)
		{
			var request = new ApiTeacherSkillRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTeacherSkillRequestModel> CreatePatch(ApiTeacherSkillRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeacherSkillRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e9e17f094bb61386855764229d03b407</Hash>
</Codenesium>*/
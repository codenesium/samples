using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiTeacherTeacherSkillServerModelMapper
	{
		public virtual ApiTeacherTeacherSkillServerResponseModel MapServerRequestToResponse(
			int teacherId,
			ApiTeacherTeacherSkillServerRequestModel request)
		{
			var response = new ApiTeacherTeacherSkillServerResponseModel();
			response.SetProperties(teacherId,
			                       request.TeacherSkillId);
			return response;
		}

		public virtual ApiTeacherTeacherSkillServerRequestModel MapServerResponseToRequest(
			ApiTeacherTeacherSkillServerResponseModel response)
		{
			var request = new ApiTeacherTeacherSkillServerRequestModel();
			request.SetProperties(
				response.TeacherSkillId);
			return request;
		}

		public virtual ApiTeacherTeacherSkillClientRequestModel MapServerResponseToClientRequest(
			ApiTeacherTeacherSkillServerResponseModel response)
		{
			var request = new ApiTeacherTeacherSkillClientRequestModel();
			request.SetProperties(
				response.TeacherSkillId);
			return request;
		}

		public JsonPatchDocument<ApiTeacherTeacherSkillServerRequestModel> CreatePatch(ApiTeacherTeacherSkillServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeacherTeacherSkillServerRequestModel>();
			patch.Replace(x => x.TeacherSkillId, model.TeacherSkillId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>0d049ef4213068167acb12524e8badc2</Hash>
</Codenesium>*/
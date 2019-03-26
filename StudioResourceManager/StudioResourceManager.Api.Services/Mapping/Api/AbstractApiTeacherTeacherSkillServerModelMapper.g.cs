using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiTeacherTeacherSkillServerModelMapper
	{
		public virtual ApiTeacherTeacherSkillServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTeacherTeacherSkillServerRequestModel request)
		{
			var response = new ApiTeacherTeacherSkillServerResponseModel();
			response.SetProperties(id,
			                       request.TeacherId,
			                       request.TeacherSkillId);
			return response;
		}

		public virtual ApiTeacherTeacherSkillServerRequestModel MapServerResponseToRequest(
			ApiTeacherTeacherSkillServerResponseModel response)
		{
			var request = new ApiTeacherTeacherSkillServerRequestModel();
			request.SetProperties(
				response.TeacherId,
				response.TeacherSkillId);
			return request;
		}

		public virtual ApiTeacherTeacherSkillClientRequestModel MapServerResponseToClientRequest(
			ApiTeacherTeacherSkillServerResponseModel response)
		{
			var request = new ApiTeacherTeacherSkillClientRequestModel();
			request.SetProperties(
				response.TeacherId,
				response.TeacherSkillId);
			return request;
		}

		public JsonPatchDocument<ApiTeacherTeacherSkillServerRequestModel> CreatePatch(ApiTeacherTeacherSkillServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeacherTeacherSkillServerRequestModel>();
			patch.Replace(x => x.TeacherId, model.TeacherId);
			patch.Replace(x => x.TeacherSkillId, model.TeacherSkillId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8c883fde55d13a58fdf58c4f76bab356</Hash>
</Codenesium>*/
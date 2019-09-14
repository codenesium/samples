using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiTeacherTeacherSkillServerModelMapper : IApiTeacherTeacherSkillServerModelMapper
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
    <Hash>38c77daeeca1a683b7056d78f94e4819</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
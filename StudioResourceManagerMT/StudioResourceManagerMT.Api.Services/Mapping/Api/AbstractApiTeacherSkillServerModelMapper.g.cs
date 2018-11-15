using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiTeacherSkillServerModelMapper
	{
		public virtual ApiTeacherSkillServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTeacherSkillServerRequestModel request)
		{
			var response = new ApiTeacherSkillServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTeacherSkillServerRequestModel MapServerResponseToRequest(
			ApiTeacherSkillServerResponseModel response)
		{
			var request = new ApiTeacherSkillServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiTeacherSkillClientRequestModel MapServerResponseToClientRequest(
			ApiTeacherSkillServerResponseModel response)
		{
			var request = new ApiTeacherSkillClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTeacherSkillServerRequestModel> CreatePatch(ApiTeacherSkillServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeacherSkillServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>228b97c4234643320d2527024db4c1e5</Hash>
</Codenesium>*/
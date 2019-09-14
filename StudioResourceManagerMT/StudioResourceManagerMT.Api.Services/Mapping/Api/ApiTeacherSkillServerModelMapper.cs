using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiTeacherSkillServerModelMapper : IApiTeacherSkillServerModelMapper
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
    <Hash>31ca51fe749c305764a4ed9c222799d4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>750fcc5298663dcba0f5d91c2ef352d5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
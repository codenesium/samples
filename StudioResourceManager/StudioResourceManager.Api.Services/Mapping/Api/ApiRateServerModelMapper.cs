using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiRateServerModelMapper : IApiRateServerModelMapper
	{
		public virtual ApiRateServerResponseModel MapServerRequestToResponse(
			int id,
			ApiRateServerRequestModel request)
		{
			var response = new ApiRateServerResponseModel();
			response.SetProperties(id,
			                       request.AmountPerMinute,
			                       request.TeacherId,
			                       request.TeacherSkillId);
			return response;
		}

		public virtual ApiRateServerRequestModel MapServerResponseToRequest(
			ApiRateServerResponseModel response)
		{
			var request = new ApiRateServerRequestModel();
			request.SetProperties(
				response.AmountPerMinute,
				response.TeacherId,
				response.TeacherSkillId);
			return request;
		}

		public virtual ApiRateClientRequestModel MapServerResponseToClientRequest(
			ApiRateServerResponseModel response)
		{
			var request = new ApiRateClientRequestModel();
			request.SetProperties(
				response.AmountPerMinute,
				response.TeacherId,
				response.TeacherSkillId);
			return request;
		}

		public JsonPatchDocument<ApiRateServerRequestModel> CreatePatch(ApiRateServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiRateServerRequestModel>();
			patch.Replace(x => x.AmountPerMinute, model.AmountPerMinute);
			patch.Replace(x => x.TeacherId, model.TeacherId);
			patch.Replace(x => x.TeacherSkillId, model.TeacherSkillId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>339dae188a404f6e76681e3abbb12ef2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
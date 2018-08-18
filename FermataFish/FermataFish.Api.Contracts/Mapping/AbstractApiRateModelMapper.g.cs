using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public abstract class AbstractApiRateModelMapper
	{
		public virtual ApiRateResponseModel MapRequestToResponse(
			int id,
			ApiRateRequestModel request)
		{
			var response = new ApiRateResponseModel();
			response.SetProperties(id,
			                       request.AmountPerMinute,
			                       request.TeacherId,
			                       request.TeacherSkillId);
			return response;
		}

		public virtual ApiRateRequestModel MapResponseToRequest(
			ApiRateResponseModel response)
		{
			var request = new ApiRateRequestModel();
			request.SetProperties(
				response.AmountPerMinute,
				response.TeacherId,
				response.TeacherSkillId);
			return request;
		}

		public JsonPatchDocument<ApiRateRequestModel> CreatePatch(ApiRateRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiRateRequestModel>();
			patch.Replace(x => x.AmountPerMinute, model.AmountPerMinute);
			patch.Replace(x => x.TeacherId, model.TeacherId);
			patch.Replace(x => x.TeacherSkillId, model.TeacherSkillId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f83b317171857291d774dc1e000cfec6</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiTeacherModelMapper
	{
		public virtual ApiTeacherResponseModel MapRequestToResponse(
			int id,
			ApiTeacherRequestModel request)
		{
			var response = new ApiTeacherResponseModel();
			response.SetProperties(id,
			                       request.Birthday,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Phone,
			                       request.UserId);
			return response;
		}

		public virtual ApiTeacherRequestModel MapResponseToRequest(
			ApiTeacherResponseModel response)
		{
			var request = new ApiTeacherRequestModel();
			request.SetProperties(
				response.Birthday,
				response.Email,
				response.FirstName,
				response.LastName,
				response.Phone,
				response.UserId);
			return request;
		}

		public JsonPatchDocument<ApiTeacherRequestModel> CreatePatch(ApiTeacherRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeacherRequestModel>();
			patch.Replace(x => x.Birthday, model.Birthday);
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.Phone, model.Phone);
			patch.Replace(x => x.UserId, model.UserId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>55957248448208dc469722e0d91e8a42</Hash>
</Codenesium>*/
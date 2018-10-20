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
			                       request.UserId,
			                       request.IsDeleted);
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
				response.UserId,
				response.IsDeleted);
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
			patch.Replace(x => x.IsDeleted, model.IsDeleted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>93912b573259960f7bb03ca60e2f6069</Hash>
</Codenesium>*/
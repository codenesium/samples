using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiAdminModelMapper
	{
		public virtual ApiAdminResponseModel MapRequestToResponse(
			int id,
			ApiAdminRequestModel request)
		{
			var response = new ApiAdminResponseModel();
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

		public virtual ApiAdminRequestModel MapResponseToRequest(
			ApiAdminResponseModel response)
		{
			var request = new ApiAdminRequestModel();
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

		public JsonPatchDocument<ApiAdminRequestModel> CreatePatch(ApiAdminRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiAdminRequestModel>();
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
    <Hash>74db6d6440e6dbe22fdeca3c9eb7a4fc</Hash>
</Codenesium>*/
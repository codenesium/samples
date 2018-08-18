using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
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
			                       request.StudioId);
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
				response.StudioId);
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
			patch.Replace(x => x.StudioId, model.StudioId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9c92bd695bc20097905e8b2f136dc1df</Hash>
</Codenesium>*/
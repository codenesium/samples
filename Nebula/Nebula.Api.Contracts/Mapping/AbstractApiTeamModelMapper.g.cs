using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public abstract class AbstractApiTeamModelMapper
	{
		public virtual ApiTeamResponseModel MapRequestToResponse(
			int id,
			ApiTeamRequestModel request)
		{
			var response = new ApiTeamResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.OrganizationId);
			return response;
		}

		public virtual ApiTeamRequestModel MapResponseToRequest(
			ApiTeamResponseModel response)
		{
			var request = new ApiTeamRequestModel();
			request.SetProperties(
				response.Name,
				response.OrganizationId);
			return request;
		}

		public JsonPatchDocument<ApiTeamRequestModel> CreatePatch(ApiTeamRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeamRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.OrganizationId, model.OrganizationId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f0f549089cbc5d8361d912b7d5c3666b</Hash>
</Codenesium>*/
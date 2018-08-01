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
    <Hash>190c6eb11a562a1babd961f4fc5ea1a2</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiTeamServerModelMapper
	{
		public virtual ApiTeamServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTeamServerRequestModel request)
		{
			var response = new ApiTeamServerResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.OrganizationId);
			return response;
		}

		public virtual ApiTeamServerRequestModel MapServerResponseToRequest(
			ApiTeamServerResponseModel response)
		{
			var request = new ApiTeamServerRequestModel();
			request.SetProperties(
				response.Name,
				response.OrganizationId);
			return request;
		}

		public virtual ApiTeamClientRequestModel MapServerResponseToClientRequest(
			ApiTeamServerResponseModel response)
		{
			var request = new ApiTeamClientRequestModel();
			request.SetProperties(
				response.Name,
				response.OrganizationId);
			return request;
		}

		public JsonPatchDocument<ApiTeamServerRequestModel> CreatePatch(ApiTeamServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTeamServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.OrganizationId, model.OrganizationId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>1b80c0a0d091919d4cf56050391953fe</Hash>
</Codenesium>*/
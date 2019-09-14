using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiTeamServerModelMapper : IApiTeamServerModelMapper
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
    <Hash>0f7d778a26ffba8383c3124c9acf510a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
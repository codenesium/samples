using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public abstract class AbstractApiTeamModelMapper
	{
		public virtual ApiTeamClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTeamClientRequestModel request)
		{
			var response = new ApiTeamClientResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.OrganizationId);
			return response;
		}

		public virtual ApiTeamClientRequestModel MapClientResponseToRequest(
			ApiTeamClientResponseModel response)
		{
			var request = new ApiTeamClientRequestModel();
			request.SetProperties(
				response.Name,
				response.OrganizationId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>4fa4485b4b5b8b9e00f528abcbf8c27b</Hash>
</Codenesium>*/
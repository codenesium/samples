using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public class ApiTeamModelMapper : IApiTeamModelMapper
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
    <Hash>8abfc265351b4ddd4136d898139560be</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
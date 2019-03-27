using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public abstract class AbstractApiMachineRefTeamModelMapper
	{
		public virtual ApiMachineRefTeamClientResponseModel MapClientRequestToResponse(
			int id,
			ApiMachineRefTeamClientRequestModel request)
		{
			var response = new ApiMachineRefTeamClientResponseModel();
			response.SetProperties(id,
			                       request.MachineId,
			                       request.TeamId);
			return response;
		}

		public virtual ApiMachineRefTeamClientRequestModel MapClientResponseToRequest(
			ApiMachineRefTeamClientResponseModel response)
		{
			var request = new ApiMachineRefTeamClientRequestModel();
			request.SetProperties(
				response.MachineId,
				response.TeamId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>a91ebafc1dd057870f15a795ae98e098</Hash>
</Codenesium>*/
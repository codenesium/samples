using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiMachineRefTeamServerModelMapper
	{
		public virtual ApiMachineRefTeamServerResponseModel MapServerRequestToResponse(
			int id,
			ApiMachineRefTeamServerRequestModel request)
		{
			var response = new ApiMachineRefTeamServerResponseModel();
			response.SetProperties(id,
			                       request.MachineId,
			                       request.TeamId);
			return response;
		}

		public virtual ApiMachineRefTeamServerRequestModel MapServerResponseToRequest(
			ApiMachineRefTeamServerResponseModel response)
		{
			var request = new ApiMachineRefTeamServerRequestModel();
			request.SetProperties(
				response.MachineId,
				response.TeamId);
			return request;
		}

		public virtual ApiMachineRefTeamClientRequestModel MapServerResponseToClientRequest(
			ApiMachineRefTeamServerResponseModel response)
		{
			var request = new ApiMachineRefTeamClientRequestModel();
			request.SetProperties(
				response.MachineId,
				response.TeamId);
			return request;
		}

		public JsonPatchDocument<ApiMachineRefTeamServerRequestModel> CreatePatch(ApiMachineRefTeamServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiMachineRefTeamServerRequestModel>();
			patch.Replace(x => x.MachineId, model.MachineId);
			patch.Replace(x => x.TeamId, model.TeamId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d200ccdbb2305d396555c74373ac35dd</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public abstract class AbstractApiMachineRefTeamModelMapper
	{
		public virtual ApiMachineRefTeamResponseModel MapRequestToResponse(
			int id,
			ApiMachineRefTeamRequestModel request)
		{
			var response = new ApiMachineRefTeamResponseModel();
			response.SetProperties(id,
			                       request.MachineId,
			                       request.TeamId);
			return response;
		}

		public virtual ApiMachineRefTeamRequestModel MapResponseToRequest(
			ApiMachineRefTeamResponseModel response)
		{
			var request = new ApiMachineRefTeamRequestModel();
			request.SetProperties(
				response.MachineId,
				response.TeamId);
			return request;
		}

		public JsonPatchDocument<ApiMachineRefTeamRequestModel> CreatePatch(ApiMachineRefTeamRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiMachineRefTeamRequestModel>();
			patch.Replace(x => x.MachineId, model.MachineId);
			patch.Replace(x => x.TeamId, model.TeamId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d24253202edd909372f4d7e8357fd843</Hash>
</Codenesium>*/
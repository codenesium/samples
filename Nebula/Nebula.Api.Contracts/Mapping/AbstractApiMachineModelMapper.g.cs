using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public abstract class AbstractApiMachineModelMapper
	{
		public virtual ApiMachineResponseModel MapRequestToResponse(
			int id,
			ApiMachineRequestModel request)
		{
			var response = new ApiMachineResponseModel();
			response.SetProperties(id,
			                       request.Description,
			                       request.JwtKey,
			                       request.LastIpAddress,
			                       request.MachineGuid,
			                       request.Name);
			return response;
		}

		public virtual ApiMachineRequestModel MapResponseToRequest(
			ApiMachineResponseModel response)
		{
			var request = new ApiMachineRequestModel();
			request.SetProperties(
				response.Description,
				response.JwtKey,
				response.LastIpAddress,
				response.MachineGuid,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiMachineRequestModel> CreatePatch(ApiMachineRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiMachineRequestModel>();
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.JwtKey, model.JwtKey);
			patch.Replace(x => x.LastIpAddress, model.LastIpAddress);
			patch.Replace(x => x.MachineGuid, model.MachineGuid);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>fc55fe0ce59ed12ef64df2c7b7c3ba30</Hash>
</Codenesium>*/
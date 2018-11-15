using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiMachineServerModelMapper
	{
		public virtual ApiMachineServerResponseModel MapServerRequestToResponse(
			int id,
			ApiMachineServerRequestModel request)
		{
			var response = new ApiMachineServerResponseModel();
			response.SetProperties(id,
			                       request.Description,
			                       request.JwtKey,
			                       request.LastIpAddress,
			                       request.MachineGuid,
			                       request.Name);
			return response;
		}

		public virtual ApiMachineServerRequestModel MapServerResponseToRequest(
			ApiMachineServerResponseModel response)
		{
			var request = new ApiMachineServerRequestModel();
			request.SetProperties(
				response.Description,
				response.JwtKey,
				response.LastIpAddress,
				response.MachineGuid,
				response.Name);
			return request;
		}

		public virtual ApiMachineClientRequestModel MapServerResponseToClientRequest(
			ApiMachineServerResponseModel response)
		{
			var request = new ApiMachineClientRequestModel();
			request.SetProperties(
				response.Description,
				response.JwtKey,
				response.LastIpAddress,
				response.MachineGuid,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiMachineServerRequestModel> CreatePatch(ApiMachineServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiMachineServerRequestModel>();
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
    <Hash>bc308de2514945426f91961daf5e029c</Hash>
</Codenesium>*/
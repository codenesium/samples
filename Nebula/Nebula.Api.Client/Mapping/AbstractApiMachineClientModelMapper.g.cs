using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public abstract class AbstractApiMachineModelMapper
	{
		public virtual ApiMachineClientResponseModel MapClientRequestToResponse(
			int id,
			ApiMachineClientRequestModel request)
		{
			var response = new ApiMachineClientResponseModel();
			response.SetProperties(id,
			                       request.Description,
			                       request.JwtKey,
			                       request.LastIpAddress,
			                       request.MachineGuid,
			                       request.Name);
			return response;
		}

		public virtual ApiMachineClientRequestModel MapClientResponseToRequest(
			ApiMachineClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>48e4c47a48dceeb8b7d5add63f01465f</Hash>
</Codenesium>*/
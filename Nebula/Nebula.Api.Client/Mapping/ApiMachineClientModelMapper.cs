using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public class ApiMachineModelMapper : IApiMachineModelMapper
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
    <Hash>0b0fb2a129351ae7f48749e6e37ac87c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
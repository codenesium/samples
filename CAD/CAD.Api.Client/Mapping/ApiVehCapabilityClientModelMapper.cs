using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiVehCapabilityModelMapper : IApiVehCapabilityModelMapper
	{
		public virtual ApiVehCapabilityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVehCapabilityClientRequestModel request)
		{
			var response = new ApiVehCapabilityClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiVehCapabilityClientRequestModel MapClientResponseToRequest(
			ApiVehCapabilityClientResponseModel response)
		{
			var request = new ApiVehCapabilityClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>bf7c05e34e2be160407e73c5a8416330</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
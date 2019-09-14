using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public class ApiTenantModelMapper : IApiTenantModelMapper
	{
		public virtual ApiTenantClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTenantClientRequestModel request)
		{
			var response = new ApiTenantClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTenantClientRequestModel MapClientResponseToRequest(
			ApiTenantClientResponseModel response)
		{
			var request = new ApiTenantClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>7b6635060208723f0dce46e967065979</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
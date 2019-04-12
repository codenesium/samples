using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public abstract class AbstractApiTenantModelMapper
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
    <Hash>d805f27d308368fd4028a58d946df181</Hash>
</Codenesium>*/
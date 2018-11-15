using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public abstract class AbstractApiOrganizationModelMapper
	{
		public virtual ApiOrganizationClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOrganizationClientRequestModel request)
		{
			var response = new ApiOrganizationClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiOrganizationClientRequestModel MapClientResponseToRequest(
			ApiOrganizationClientResponseModel response)
		{
			var request = new ApiOrganizationClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>77a54599bfcad227ea39d7a0d16fc855</Hash>
</Codenesium>*/
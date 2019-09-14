using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public class ApiOrganizationModelMapper : IApiOrganizationModelMapper
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
    <Hash>13eebed41716f11224a4946f9dca4ea6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
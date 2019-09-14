using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiOfficerModelMapper : IApiOfficerModelMapper
	{
		public virtual ApiOfficerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiOfficerClientRequestModel request)
		{
			var response = new ApiOfficerClientResponseModel();
			response.SetProperties(id,
			                       request.Badge,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Password);
			return response;
		}

		public virtual ApiOfficerClientRequestModel MapClientResponseToRequest(
			ApiOfficerClientResponseModel response)
		{
			var request = new ApiOfficerClientRequestModel();
			request.SetProperties(
				response.Badge,
				response.Email,
				response.FirstName,
				response.LastName,
				response.Password);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>8f65b6fa01ac9d00a9e9e2a8e999f191</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiOfficerModelMapper
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
    <Hash>7cb1669db6fc71cf2fc9c9b02785bb16</Hash>
</Codenesium>*/
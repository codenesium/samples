using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public class ApiEventModelMapper : IApiEventModelMapper
	{
		public virtual ApiEventClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventClientRequestModel request)
		{
			var response = new ApiEventClientResponseModel();
			response.SetProperties(id,
			                       request.Address1,
			                       request.Address2,
			                       request.CityId,
			                       request.Date,
			                       request.Description,
			                       request.EndDate,
			                       request.Facebook,
			                       request.Name,
			                       request.StartDate,
			                       request.Website);
			return response;
		}

		public virtual ApiEventClientRequestModel MapClientResponseToRequest(
			ApiEventClientResponseModel response)
		{
			var request = new ApiEventClientRequestModel();
			request.SetProperties(
				response.Address1,
				response.Address2,
				response.CityId,
				response.Date,
				response.Description,
				response.EndDate,
				response.Facebook,
				response.Name,
				response.StartDate,
				response.Website);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>93db23487e8cabcf2f988b505f6a2403</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
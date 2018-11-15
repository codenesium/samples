using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiEventModelMapper
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
    <Hash>9c5c4c26ebf9a57642501ce3acf34b79</Hash>
</Codenesium>*/
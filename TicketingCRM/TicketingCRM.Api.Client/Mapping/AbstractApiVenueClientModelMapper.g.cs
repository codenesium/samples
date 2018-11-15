using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiVenueModelMapper
	{
		public virtual ApiVenueClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVenueClientRequestModel request)
		{
			var response = new ApiVenueClientResponseModel();
			response.SetProperties(id,
			                       request.Address1,
			                       request.Address2,
			                       request.AdminId,
			                       request.Email,
			                       request.Facebook,
			                       request.Name,
			                       request.Phone,
			                       request.ProvinceId,
			                       request.Website);
			return response;
		}

		public virtual ApiVenueClientRequestModel MapClientResponseToRequest(
			ApiVenueClientResponseModel response)
		{
			var request = new ApiVenueClientRequestModel();
			request.SetProperties(
				response.Address1,
				response.Address2,
				response.AdminId,
				response.Email,
				response.Facebook,
				response.Name,
				response.Phone,
				response.ProvinceId,
				response.Website);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>9ea8bbbf5fae2f00ea9bb1865d823ab3</Hash>
</Codenesium>*/
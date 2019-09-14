using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public class ApiVenueModelMapper : IApiVenueModelMapper
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
    <Hash>8d023bcff3a7bf5cb71f0ccc751db36c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
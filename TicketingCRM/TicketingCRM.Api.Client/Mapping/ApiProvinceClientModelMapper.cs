using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public class ApiProvinceModelMapper : IApiProvinceModelMapper
	{
		public virtual ApiProvinceClientResponseModel MapClientRequestToResponse(
			int id,
			ApiProvinceClientRequestModel request)
		{
			var response = new ApiProvinceClientResponseModel();
			response.SetProperties(id,
			                       request.CountryId,
			                       request.Name);
			return response;
		}

		public virtual ApiProvinceClientRequestModel MapClientResponseToRequest(
			ApiProvinceClientResponseModel response)
		{
			var request = new ApiProvinceClientRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>cc2618e154ca2d3fefaa51719713b51a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
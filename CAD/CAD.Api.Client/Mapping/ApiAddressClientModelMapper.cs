using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiAddressModelMapper : IApiAddressModelMapper
	{
		public virtual ApiAddressClientResponseModel MapClientRequestToResponse(
			int id,
			ApiAddressClientRequestModel request)
		{
			var response = new ApiAddressClientResponseModel();
			response.SetProperties(id,
			                       request.Address1,
			                       request.Address2,
			                       request.City,
			                       request.State,
			                       request.Zip);
			return response;
		}

		public virtual ApiAddressClientRequestModel MapClientResponseToRequest(
			ApiAddressClientResponseModel response)
		{
			var request = new ApiAddressClientRequestModel();
			request.SetProperties(
				response.Address1,
				response.Address2,
				response.City,
				response.State,
				response.Zip);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>dbe77756f87c4d6f790d474d4b0a8e94</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
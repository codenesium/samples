using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiPersonModelMapper : IApiPersonModelMapper
	{
		public virtual ApiPersonClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPersonClientRequestModel request)
		{
			var response = new ApiPersonClientResponseModel();
			response.SetProperties(id,
			                       request.FirstName,
			                       request.LastName,
			                       request.Phone,
			                       request.Ssn);
			return response;
		}

		public virtual ApiPersonClientRequestModel MapClientResponseToRequest(
			ApiPersonClientResponseModel response)
		{
			var request = new ApiPersonClientRequestModel();
			request.SetProperties(
				response.FirstName,
				response.LastName,
				response.Phone,
				response.Ssn);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>a774b7669ebaf36d948a10ea66a10c88</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
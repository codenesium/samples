using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public class ApiPenModelMapper : IApiPenModelMapper
	{
		public virtual ApiPenClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPenClientRequestModel request)
		{
			var response = new ApiPenClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPenClientRequestModel MapClientResponseToRequest(
			ApiPenClientResponseModel response)
		{
			var request = new ApiPenClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>ffd35573b7c1137e15ee448c171de1a7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
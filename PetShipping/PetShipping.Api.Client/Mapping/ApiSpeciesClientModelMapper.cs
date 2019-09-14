using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiSpeciesModelMapper : IApiSpeciesModelMapper
	{
		public virtual ApiSpeciesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSpeciesClientRequestModel request)
		{
			var response = new ApiSpeciesClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSpeciesClientRequestModel MapClientResponseToRequest(
			ApiSpeciesClientResponseModel response)
		{
			var request = new ApiSpeciesClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>3d53e4e2ce0685e0d57dec12cc5262cf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
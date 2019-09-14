using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
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
    <Hash>7e5df5e288cf71bbfb8a9df79b6415ec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
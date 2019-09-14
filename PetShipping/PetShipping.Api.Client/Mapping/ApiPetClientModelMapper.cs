using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiPetModelMapper : IApiPetModelMapper
	{
		public virtual ApiPetClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPetClientRequestModel request)
		{
			var response = new ApiPetClientResponseModel();
			response.SetProperties(id,
			                       request.BreedId,
			                       request.ClientId,
			                       request.Name,
			                       request.Weight);
			return response;
		}

		public virtual ApiPetClientRequestModel MapClientResponseToRequest(
			ApiPetClientResponseModel response)
		{
			var request = new ApiPetClientRequestModel();
			request.SetProperties(
				response.BreedId,
				response.ClientId,
				response.Name,
				response.Weight);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>4e568fbcbd30cbd7c7325612373b4410</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public abstract class AbstractApiPetModelMapper
	{
		public virtual ApiPetClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPetClientRequestModel request)
		{
			var response = new ApiPetClientResponseModel();
			response.SetProperties(id,
			                       request.AcquiredDate,
			                       request.BreedId,
			                       request.Description,
			                       request.PenId,
			                       request.Price);
			return response;
		}

		public virtual ApiPetClientRequestModel MapClientResponseToRequest(
			ApiPetClientResponseModel response)
		{
			var request = new ApiPetClientRequestModel();
			request.SetProperties(
				response.AcquiredDate,
				response.BreedId,
				response.Description,
				response.PenId,
				response.Price);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>657ec19ecc1a87aadae95901f4a286d5</Hash>
</Codenesium>*/
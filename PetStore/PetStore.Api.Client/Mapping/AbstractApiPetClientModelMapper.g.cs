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
			                       request.Price,
			                       request.SpeciesId);
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
				response.Price,
				response.SpeciesId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d0c75c09f44f7f71316d6f0dd9ab448c</Hash>
</Codenesium>*/
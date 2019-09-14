using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public class ApiPetModelMapper : IApiPetModelMapper
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
    <Hash>dc31950872bc80153d6198728e9f5f91</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
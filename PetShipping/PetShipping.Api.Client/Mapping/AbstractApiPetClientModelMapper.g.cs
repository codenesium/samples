using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiPetModelMapper
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
    <Hash>48a5401e586b3065325c793999302646</Hash>
</Codenesium>*/
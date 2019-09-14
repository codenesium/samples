using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPetServerModelMapper : IApiPetServerModelMapper
	{
		public virtual ApiPetServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPetServerRequestModel request)
		{
			var response = new ApiPetServerResponseModel();
			response.SetProperties(id,
			                       request.BreedId,
			                       request.ClientId,
			                       request.Name,
			                       request.Weight);
			return response;
		}

		public virtual ApiPetServerRequestModel MapServerResponseToRequest(
			ApiPetServerResponseModel response)
		{
			var request = new ApiPetServerRequestModel();
			request.SetProperties(
				response.BreedId,
				response.ClientId,
				response.Name,
				response.Weight);
			return request;
		}

		public virtual ApiPetClientRequestModel MapServerResponseToClientRequest(
			ApiPetServerResponseModel response)
		{
			var request = new ApiPetClientRequestModel();
			request.SetProperties(
				response.BreedId,
				response.ClientId,
				response.Name,
				response.Weight);
			return request;
		}

		public JsonPatchDocument<ApiPetServerRequestModel> CreatePatch(ApiPetServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPetServerRequestModel>();
			patch.Replace(x => x.BreedId, model.BreedId);
			patch.Replace(x => x.ClientId, model.ClientId);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Weight, model.Weight);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>64ee5ee1e39b2752ecc25d61c0b631a2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
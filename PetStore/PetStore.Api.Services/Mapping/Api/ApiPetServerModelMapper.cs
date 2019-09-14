using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class ApiPetServerModelMapper : IApiPetServerModelMapper
	{
		public virtual ApiPetServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPetServerRequestModel request)
		{
			var response = new ApiPetServerResponseModel();
			response.SetProperties(id,
			                       request.AcquiredDate,
			                       request.BreedId,
			                       request.Description,
			                       request.PenId,
			                       request.Price);
			return response;
		}

		public virtual ApiPetServerRequestModel MapServerResponseToRequest(
			ApiPetServerResponseModel response)
		{
			var request = new ApiPetServerRequestModel();
			request.SetProperties(
				response.AcquiredDate,
				response.BreedId,
				response.Description,
				response.PenId,
				response.Price);
			return request;
		}

		public virtual ApiPetClientRequestModel MapServerResponseToClientRequest(
			ApiPetServerResponseModel response)
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

		public JsonPatchDocument<ApiPetServerRequestModel> CreatePatch(ApiPetServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPetServerRequestModel>();
			patch.Replace(x => x.AcquiredDate, model.AcquiredDate);
			patch.Replace(x => x.BreedId, model.BreedId);
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.PenId, model.PenId);
			patch.Replace(x => x.Price, model.Price);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>618b946a1ea9d7c7138cad030499c0a5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
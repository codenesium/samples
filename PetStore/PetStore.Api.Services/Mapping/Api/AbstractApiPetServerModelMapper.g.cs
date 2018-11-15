using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractApiPetServerModelMapper
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
			                       request.Price,
			                       request.SpeciesId);
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
				response.Price,
				response.SpeciesId);
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
				response.Price,
				response.SpeciesId);
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
			patch.Replace(x => x.SpeciesId, model.SpeciesId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>1f57b85e1d8bbaf18ef7f4e768dd3d41</Hash>
</Codenesium>*/
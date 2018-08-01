using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
	public abstract class AbstractApiPetModelMapper
	{
		public virtual ApiPetResponseModel MapRequestToResponse(
			int id,
			ApiPetRequestModel request)
		{
			var response = new ApiPetResponseModel();
			response.SetProperties(id,
			                       request.AcquiredDate,
			                       request.BreedId,
			                       request.Description,
			                       request.PenId,
			                       request.Price,
			                       request.SpeciesId);
			return response;
		}

		public virtual ApiPetRequestModel MapResponseToRequest(
			ApiPetResponseModel response)
		{
			var request = new ApiPetRequestModel();
			request.SetProperties(
				response.AcquiredDate,
				response.BreedId,
				response.Description,
				response.PenId,
				response.Price,
				response.SpeciesId);
			return request;
		}

		public JsonPatchDocument<ApiPetRequestModel> CreatePatch(ApiPetRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPetRequestModel>();
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
    <Hash>6286fdb93023062f395372869632e0c4</Hash>
</Codenesium>*/
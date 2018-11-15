using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPetServerModelMapper
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
    <Hash>78791f9564d59e1350a3672e35f2f374</Hash>
</Codenesium>*/
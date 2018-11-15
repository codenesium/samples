using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractApiSpeciesServerModelMapper
	{
		public virtual ApiSpeciesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSpeciesServerRequestModel request)
		{
			var response = new ApiSpeciesServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSpeciesServerRequestModel MapServerResponseToRequest(
			ApiSpeciesServerResponseModel response)
		{
			var request = new ApiSpeciesServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiSpeciesClientRequestModel MapServerResponseToClientRequest(
			ApiSpeciesServerResponseModel response)
		{
			var request = new ApiSpeciesClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiSpeciesServerRequestModel> CreatePatch(ApiSpeciesServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpeciesServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9530bc2ca72f707f4c9ed7d2c0e544c5</Hash>
</Codenesium>*/
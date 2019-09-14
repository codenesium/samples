using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiSpeciesServerModelMapper : IApiSpeciesServerModelMapper
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
    <Hash>363a39863cd6f016c3bce1d7d304e413</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
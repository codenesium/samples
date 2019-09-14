using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class ApiPenServerModelMapper : IApiPenServerModelMapper
	{
		public virtual ApiPenServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPenServerRequestModel request)
		{
			var response = new ApiPenServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPenServerRequestModel MapServerResponseToRequest(
			ApiPenServerResponseModel response)
		{
			var request = new ApiPenServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiPenClientRequestModel MapServerResponseToClientRequest(
			ApiPenServerResponseModel response)
		{
			var request = new ApiPenClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPenServerRequestModel> CreatePatch(ApiPenServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPenServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>4abe707c1433a48086e0df55cc9cf6c8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractApiPenServerModelMapper
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
    <Hash>84c35ba3a29fc007e97b57f922139cfc</Hash>
</Codenesium>*/
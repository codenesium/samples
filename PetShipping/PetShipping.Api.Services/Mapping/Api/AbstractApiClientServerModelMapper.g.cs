using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiClientServerModelMapper
	{
		public virtual ApiClientServerResponseModel MapServerRequestToResponse(
			int id,
			ApiClientServerRequestModel request)
		{
			var response = new ApiClientServerResponseModel();
			response.SetProperties(id,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Note,
			                       request.Phone);
			return response;
		}

		public virtual ApiClientServerRequestModel MapServerResponseToRequest(
			ApiClientServerResponseModel response)
		{
			var request = new ApiClientServerRequestModel();
			request.SetProperties(
				response.Email,
				response.FirstName,
				response.LastName,
				response.Note,
				response.Phone);
			return request;
		}

		public virtual ApiClientClientRequestModel MapServerResponseToClientRequest(
			ApiClientServerResponseModel response)
		{
			var request = new ApiClientClientRequestModel();
			request.SetProperties(
				response.Email,
				response.FirstName,
				response.LastName,
				response.Note,
				response.Phone);
			return request;
		}

		public JsonPatchDocument<ApiClientServerRequestModel> CreatePatch(ApiClientServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiClientServerRequestModel>();
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.Note, model.Note);
			patch.Replace(x => x.Phone, model.Phone);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>0c6e2ab79099f4f37ad9b130749665d6</Hash>
</Codenesium>*/
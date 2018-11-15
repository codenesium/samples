using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiHandlerServerModelMapper
	{
		public virtual ApiHandlerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiHandlerServerRequestModel request)
		{
			var response = new ApiHandlerServerResponseModel();
			response.SetProperties(id,
			                       request.CountryId,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Phone);
			return response;
		}

		public virtual ApiHandlerServerRequestModel MapServerResponseToRequest(
			ApiHandlerServerResponseModel response)
		{
			var request = new ApiHandlerServerRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Email,
				response.FirstName,
				response.LastName,
				response.Phone);
			return request;
		}

		public virtual ApiHandlerClientRequestModel MapServerResponseToClientRequest(
			ApiHandlerServerResponseModel response)
		{
			var request = new ApiHandlerClientRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Email,
				response.FirstName,
				response.LastName,
				response.Phone);
			return request;
		}

		public JsonPatchDocument<ApiHandlerServerRequestModel> CreatePatch(ApiHandlerServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiHandlerServerRequestModel>();
			patch.Replace(x => x.CountryId, model.CountryId);
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.Phone, model.Phone);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>1c68e89429557a57316f245b13576dc6</Hash>
</Codenesium>*/
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiClientModelMapper
	{
		public virtual ApiClientResponseModel MapRequestToResponse(
			int id,
			ApiClientRequestModel request)
		{
			var response = new ApiClientResponseModel();
			response.SetProperties(id,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Notes,
			                       request.Phone);
			return response;
		}

		public virtual ApiClientRequestModel MapResponseToRequest(
			ApiClientResponseModel response)
		{
			var request = new ApiClientRequestModel();
			request.SetProperties(
				response.Email,
				response.FirstName,
				response.LastName,
				response.Notes,
				response.Phone);
			return request;
		}

		public JsonPatchDocument<ApiClientRequestModel> CreatePatch(ApiClientRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiClientRequestModel>();
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.Notes, model.Notes);
			patch.Replace(x => x.Phone, model.Phone);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8ec685fbc999fdd4107858fb302bacf5</Hash>
</Codenesium>*/
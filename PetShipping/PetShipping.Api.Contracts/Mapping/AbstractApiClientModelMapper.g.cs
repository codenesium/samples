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
    <Hash>22fc5f2fd5ecf822714d29c2e6e65e92</Hash>
</Codenesium>*/
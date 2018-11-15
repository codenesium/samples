using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiCountryServerModelMapper
	{
		public virtual ApiCountryServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCountryServerRequestModel request)
		{
			var response = new ApiCountryServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiCountryServerRequestModel MapServerResponseToRequest(
			ApiCountryServerResponseModel response)
		{
			var request = new ApiCountryServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiCountryClientRequestModel MapServerResponseToClientRequest(
			ApiCountryServerResponseModel response)
		{
			var request = new ApiCountryClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiCountryServerRequestModel> CreatePatch(ApiCountryServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCountryServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>122041c309362821d86f5de351f25ef2</Hash>
</Codenesium>*/
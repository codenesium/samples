using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiAirlineServerModelMapper
	{
		public virtual ApiAirlineServerResponseModel MapServerRequestToResponse(
			int id,
			ApiAirlineServerRequestModel request)
		{
			var response = new ApiAirlineServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiAirlineServerRequestModel MapServerResponseToRequest(
			ApiAirlineServerResponseModel response)
		{
			var request = new ApiAirlineServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiAirlineClientRequestModel MapServerResponseToClientRequest(
			ApiAirlineServerResponseModel response)
		{
			var request = new ApiAirlineClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiAirlineServerRequestModel> CreatePatch(ApiAirlineServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiAirlineServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e37d63fa453a52b7b8c91d8ed4d8a7e4</Hash>
</Codenesium>*/
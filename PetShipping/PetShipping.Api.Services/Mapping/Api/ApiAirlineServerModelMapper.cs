using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiAirlineServerModelMapper : IApiAirlineServerModelMapper
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
    <Hash>3e8fb36c8b2c830e34c658a9de07ef6f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
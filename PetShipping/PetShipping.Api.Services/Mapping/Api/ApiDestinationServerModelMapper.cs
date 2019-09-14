using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiDestinationServerModelMapper : IApiDestinationServerModelMapper
	{
		public virtual ApiDestinationServerResponseModel MapServerRequestToResponse(
			int id,
			ApiDestinationServerRequestModel request)
		{
			var response = new ApiDestinationServerResponseModel();
			response.SetProperties(id,
			                       request.CountryId,
			                       request.Name,
			                       request.Order);
			return response;
		}

		public virtual ApiDestinationServerRequestModel MapServerResponseToRequest(
			ApiDestinationServerResponseModel response)
		{
			var request = new ApiDestinationServerRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Name,
				response.Order);
			return request;
		}

		public virtual ApiDestinationClientRequestModel MapServerResponseToClientRequest(
			ApiDestinationServerResponseModel response)
		{
			var request = new ApiDestinationClientRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Name,
				response.Order);
			return request;
		}

		public JsonPatchDocument<ApiDestinationServerRequestModel> CreatePatch(ApiDestinationServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDestinationServerRequestModel>();
			patch.Replace(x => x.CountryId, model.CountryId);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Order, model.Order);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>1e2735245ba91528663808fc0e50636b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
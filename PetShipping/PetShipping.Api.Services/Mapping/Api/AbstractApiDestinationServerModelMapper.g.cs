using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiDestinationServerModelMapper
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
    <Hash>bf3d9f02e7ff606e1f9cd1745b977908</Hash>
</Codenesium>*/
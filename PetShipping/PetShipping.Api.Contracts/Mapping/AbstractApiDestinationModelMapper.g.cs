using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiDestinationModelMapper
	{
		public virtual ApiDestinationResponseModel MapRequestToResponse(
			int id,
			ApiDestinationRequestModel request)
		{
			var response = new ApiDestinationResponseModel();
			response.SetProperties(id,
			                       request.CountryId,
			                       request.Name,
			                       request.Order);
			return response;
		}

		public virtual ApiDestinationRequestModel MapResponseToRequest(
			ApiDestinationResponseModel response)
		{
			var request = new ApiDestinationRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Name,
				response.Order);
			return request;
		}

		public JsonPatchDocument<ApiDestinationRequestModel> CreatePatch(ApiDestinationRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDestinationRequestModel>();
			patch.Replace(x => x.CountryId, model.CountryId);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Order, model.Order);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>2fb8ca18c23cb7dc482a38727d4bec4e</Hash>
</Codenesium>*/
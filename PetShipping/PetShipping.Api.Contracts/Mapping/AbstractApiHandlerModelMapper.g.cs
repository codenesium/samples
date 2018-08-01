using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiHandlerModelMapper
	{
		public virtual ApiHandlerResponseModel MapRequestToResponse(
			int id,
			ApiHandlerRequestModel request)
		{
			var response = new ApiHandlerResponseModel();
			response.SetProperties(id,
			                       request.CountryId,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Phone);
			return response;
		}

		public virtual ApiHandlerRequestModel MapResponseToRequest(
			ApiHandlerResponseModel response)
		{
			var request = new ApiHandlerRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Email,
				response.FirstName,
				response.LastName,
				response.Phone);
			return request;
		}

		public JsonPatchDocument<ApiHandlerRequestModel> CreatePatch(ApiHandlerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiHandlerRequestModel>();
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
    <Hash>2b0be8969032a6b425aa917335fdd678</Hash>
</Codenesium>*/
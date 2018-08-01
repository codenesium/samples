using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiAirlineModelMapper
	{
		public virtual ApiAirlineResponseModel MapRequestToResponse(
			int id,
			ApiAirlineRequestModel request)
		{
			var response = new ApiAirlineResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiAirlineRequestModel MapResponseToRequest(
			ApiAirlineResponseModel response)
		{
			var request = new ApiAirlineRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiAirlineRequestModel> CreatePatch(ApiAirlineRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiAirlineRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>43b3c4ef06b745a8d2bbcc370a80dd5b</Hash>
</Codenesium>*/
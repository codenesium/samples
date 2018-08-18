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
    <Hash>ea340e11156459f398a9fa5370dcfd12</Hash>
</Codenesium>*/
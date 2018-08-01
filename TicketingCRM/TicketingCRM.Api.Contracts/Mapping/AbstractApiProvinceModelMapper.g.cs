using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public abstract class AbstractApiProvinceModelMapper
	{
		public virtual ApiProvinceResponseModel MapRequestToResponse(
			int id,
			ApiProvinceRequestModel request)
		{
			var response = new ApiProvinceResponseModel();
			response.SetProperties(id,
			                       request.CountryId,
			                       request.Name);
			return response;
		}

		public virtual ApiProvinceRequestModel MapResponseToRequest(
			ApiProvinceResponseModel response)
		{
			var request = new ApiProvinceRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiProvinceRequestModel> CreatePatch(ApiProvinceRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProvinceRequestModel>();
			patch.Replace(x => x.CountryId, model.CountryId);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>fdaaab5f317e0c9fb886a35e89c6f4f9</Hash>
</Codenesium>*/
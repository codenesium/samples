using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiCountryRequirementModelMapper
	{
		public virtual ApiCountryRequirementResponseModel MapRequestToResponse(
			int id,
			ApiCountryRequirementRequestModel request)
		{
			var response = new ApiCountryRequirementResponseModel();
			response.SetProperties(id,
			                       request.CountryId,
			                       request.Detail);
			return response;
		}

		public virtual ApiCountryRequirementRequestModel MapResponseToRequest(
			ApiCountryRequirementResponseModel response)
		{
			var request = new ApiCountryRequirementRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Detail);
			return request;
		}

		public JsonPatchDocument<ApiCountryRequirementRequestModel> CreatePatch(ApiCountryRequirementRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCountryRequirementRequestModel>();
			patch.Replace(x => x.CountryId, model.CountryId);
			patch.Replace(x => x.Detail, model.Detail);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b8d64d338d5d016fb3aab6df8b00f0c2</Hash>
</Codenesium>*/
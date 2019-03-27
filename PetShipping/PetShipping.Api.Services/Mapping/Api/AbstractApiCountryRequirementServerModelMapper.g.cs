using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiCountryRequirementServerModelMapper
	{
		public virtual ApiCountryRequirementServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCountryRequirementServerRequestModel request)
		{
			var response = new ApiCountryRequirementServerResponseModel();
			response.SetProperties(id,
			                       request.CountryId,
			                       request.Details);
			return response;
		}

		public virtual ApiCountryRequirementServerRequestModel MapServerResponseToRequest(
			ApiCountryRequirementServerResponseModel response)
		{
			var request = new ApiCountryRequirementServerRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Details);
			return request;
		}

		public virtual ApiCountryRequirementClientRequestModel MapServerResponseToClientRequest(
			ApiCountryRequirementServerResponseModel response)
		{
			var request = new ApiCountryRequirementClientRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Details);
			return request;
		}

		public JsonPatchDocument<ApiCountryRequirementServerRequestModel> CreatePatch(ApiCountryRequirementServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCountryRequirementServerRequestModel>();
			patch.Replace(x => x.CountryId, model.CountryId);
			patch.Replace(x => x.Details, model.Details);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f0be902a31fe1d85d35c17ff833e7ffc</Hash>
</Codenesium>*/
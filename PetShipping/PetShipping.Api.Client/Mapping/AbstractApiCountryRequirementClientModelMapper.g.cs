using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiCountryRequirementModelMapper
	{
		public virtual ApiCountryRequirementClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCountryRequirementClientRequestModel request)
		{
			var response = new ApiCountryRequirementClientResponseModel();
			response.SetProperties(id,
			                       request.CountryId,
			                       request.Detail);
			return response;
		}

		public virtual ApiCountryRequirementClientRequestModel MapClientResponseToRequest(
			ApiCountryRequirementClientResponseModel response)
		{
			var request = new ApiCountryRequirementClientRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Detail);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>29a0e3f9ef3afd340e0f68607e225353</Hash>
</Codenesium>*/
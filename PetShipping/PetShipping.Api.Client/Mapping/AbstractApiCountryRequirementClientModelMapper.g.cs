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
			                       request.Details);
			return response;
		}

		public virtual ApiCountryRequirementClientRequestModel MapClientResponseToRequest(
			ApiCountryRequirementClientResponseModel response)
		{
			var request = new ApiCountryRequirementClientRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Details);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>2c21ae03abfc7cce6f5ec37ad8b7726e</Hash>
</Codenesium>*/
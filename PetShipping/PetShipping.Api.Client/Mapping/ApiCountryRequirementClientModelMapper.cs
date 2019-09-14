using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiCountryRequirementModelMapper : IApiCountryRequirementModelMapper
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
    <Hash>a07a6db1a8c48f9c8dcd50705e46860c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
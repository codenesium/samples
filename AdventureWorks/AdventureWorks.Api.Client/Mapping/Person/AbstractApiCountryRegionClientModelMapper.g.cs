using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiCountryRegionModelMapper
	{
		public virtual ApiCountryRegionClientResponseModel MapClientRequestToResponse(
			string countryRegionCode,
			ApiCountryRegionClientRequestModel request)
		{
			var response = new ApiCountryRegionClientResponseModel();
			response.SetProperties(countryRegionCode,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiCountryRegionClientRequestModel MapClientResponseToRequest(
			ApiCountryRegionClientResponseModel response)
		{
			var request = new ApiCountryRegionClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>ecefb07329260bd9990a790de8c82ba3</Hash>
</Codenesium>*/
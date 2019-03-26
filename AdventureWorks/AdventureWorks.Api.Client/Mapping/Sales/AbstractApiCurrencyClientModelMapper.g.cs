using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiCurrencyModelMapper
	{
		public virtual ApiCurrencyClientResponseModel MapClientRequestToResponse(
			string currencyCode,
			ApiCurrencyClientRequestModel request)
		{
			var response = new ApiCurrencyClientResponseModel();
			response.SetProperties(currencyCode,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiCurrencyClientRequestModel MapClientResponseToRequest(
			ApiCurrencyClientResponseModel response)
		{
			var request = new ApiCurrencyClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>b5c5a445201aa3c7cacdacfcd7150b29</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiCurrencyRateModelMapper
	{
		public virtual ApiCurrencyRateClientResponseModel MapClientRequestToResponse(
			int currencyRateID,
			ApiCurrencyRateClientRequestModel request)
		{
			var response = new ApiCurrencyRateClientResponseModel();
			response.SetProperties(currencyRateID,
			                       request.AverageRate,
			                       request.CurrencyRateDate,
			                       request.EndOfDayRate,
			                       request.FromCurrencyCode,
			                       request.ModifiedDate,
			                       request.ToCurrencyCode);
			return response;
		}

		public virtual ApiCurrencyRateClientRequestModel MapClientResponseToRequest(
			ApiCurrencyRateClientResponseModel response)
		{
			var request = new ApiCurrencyRateClientRequestModel();
			request.SetProperties(
				response.AverageRate,
				response.CurrencyRateDate,
				response.EndOfDayRate,
				response.FromCurrencyCode,
				response.ModifiedDate,
				response.ToCurrencyCode);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>71e0b3954ceb8ee36119fb8bd7726819</Hash>
</Codenesium>*/
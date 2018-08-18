using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiCurrencyRateModelMapper
	{
		public virtual ApiCurrencyRateResponseModel MapRequestToResponse(
			int currencyRateID,
			ApiCurrencyRateRequestModel request)
		{
			var response = new ApiCurrencyRateResponseModel();
			response.SetProperties(currencyRateID,
			                       request.AverageRate,
			                       request.CurrencyRateDate,
			                       request.EndOfDayRate,
			                       request.FromCurrencyCode,
			                       request.ModifiedDate,
			                       request.ToCurrencyCode);
			return response;
		}

		public virtual ApiCurrencyRateRequestModel MapResponseToRequest(
			ApiCurrencyRateResponseModel response)
		{
			var request = new ApiCurrencyRateRequestModel();
			request.SetProperties(
				response.AverageRate,
				response.CurrencyRateDate,
				response.EndOfDayRate,
				response.FromCurrencyCode,
				response.ModifiedDate,
				response.ToCurrencyCode);
			return request;
		}

		public JsonPatchDocument<ApiCurrencyRateRequestModel> CreatePatch(ApiCurrencyRateRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCurrencyRateRequestModel>();
			patch.Replace(x => x.AverageRate, model.AverageRate);
			patch.Replace(x => x.CurrencyRateDate, model.CurrencyRateDate);
			patch.Replace(x => x.EndOfDayRate, model.EndOfDayRate);
			patch.Replace(x => x.FromCurrencyCode, model.FromCurrencyCode);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.ToCurrencyCode, model.ToCurrencyCode);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9631a8a9beaacf6504b9d6ef1c881b84</Hash>
</Codenesium>*/
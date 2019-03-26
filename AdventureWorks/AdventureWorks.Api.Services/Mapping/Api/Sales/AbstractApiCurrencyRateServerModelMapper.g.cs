using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiCurrencyRateServerModelMapper
	{
		public virtual ApiCurrencyRateServerResponseModel MapServerRequestToResponse(
			int currencyRateID,
			ApiCurrencyRateServerRequestModel request)
		{
			var response = new ApiCurrencyRateServerResponseModel();
			response.SetProperties(currencyRateID,
			                       request.AverageRate,
			                       request.CurrencyRateDate,
			                       request.EndOfDayRate,
			                       request.FromCurrencyCode,
			                       request.ModifiedDate,
			                       request.ToCurrencyCode);
			return response;
		}

		public virtual ApiCurrencyRateServerRequestModel MapServerResponseToRequest(
			ApiCurrencyRateServerResponseModel response)
		{
			var request = new ApiCurrencyRateServerRequestModel();
			request.SetProperties(
				response.AverageRate,
				response.CurrencyRateDate,
				response.EndOfDayRate,
				response.FromCurrencyCode,
				response.ModifiedDate,
				response.ToCurrencyCode);
			return request;
		}

		public virtual ApiCurrencyRateClientRequestModel MapServerResponseToClientRequest(
			ApiCurrencyRateServerResponseModel response)
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

		public JsonPatchDocument<ApiCurrencyRateServerRequestModel> CreatePatch(ApiCurrencyRateServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCurrencyRateServerRequestModel>();
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
    <Hash>a08831c6fb4229b9f4022f08bcee16bb</Hash>
</Codenesium>*/
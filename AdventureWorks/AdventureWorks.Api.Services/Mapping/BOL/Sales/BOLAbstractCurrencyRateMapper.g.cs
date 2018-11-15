using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCurrencyRateMapper
	{
		public virtual BOCurrencyRate MapModelToBO(
			int currencyRateID,
			ApiCurrencyRateServerRequestModel model
			)
		{
			BOCurrencyRate boCurrencyRate = new BOCurrencyRate();
			boCurrencyRate.SetProperties(
				currencyRateID,
				model.AverageRate,
				model.CurrencyRateDate,
				model.EndOfDayRate,
				model.FromCurrencyCode,
				model.ModifiedDate,
				model.ToCurrencyCode);
			return boCurrencyRate;
		}

		public virtual ApiCurrencyRateServerResponseModel MapBOToModel(
			BOCurrencyRate boCurrencyRate)
		{
			var model = new ApiCurrencyRateServerResponseModel();

			model.SetProperties(boCurrencyRate.CurrencyRateID, boCurrencyRate.AverageRate, boCurrencyRate.CurrencyRateDate, boCurrencyRate.EndOfDayRate, boCurrencyRate.FromCurrencyCode, boCurrencyRate.ModifiedDate, boCurrencyRate.ToCurrencyCode);

			return model;
		}

		public virtual List<ApiCurrencyRateServerResponseModel> MapBOToModel(
			List<BOCurrencyRate> items)
		{
			List<ApiCurrencyRateServerResponseModel> response = new List<ApiCurrencyRateServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f60b679070857e1dcedcc56727b09bf8</Hash>
</Codenesium>*/
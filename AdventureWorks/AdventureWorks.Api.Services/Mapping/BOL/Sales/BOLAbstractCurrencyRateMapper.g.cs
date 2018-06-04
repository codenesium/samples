using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCurrencyRateMapper
	{
		public virtual BOCurrencyRate MapModelToBO(
			int currencyRateID,
			ApiCurrencyRateRequestModel model
			)
		{
			BOCurrencyRate BOCurrencyRate = new BOCurrencyRate();

			BOCurrencyRate.SetProperties(
				currencyRateID,
				model.AverageRate,
				model.CurrencyRateDate,
				model.EndOfDayRate,
				model.FromCurrencyCode,
				model.ModifiedDate,
				model.ToCurrencyCode);
			return BOCurrencyRate;
		}

		public virtual ApiCurrencyRateResponseModel MapBOToModel(
			BOCurrencyRate BOCurrencyRate)
		{
			if (BOCurrencyRate == null)
			{
				return null;
			}

			var model = new ApiCurrencyRateResponseModel();

			model.SetProperties(BOCurrencyRate.AverageRate, BOCurrencyRate.CurrencyRateDate, BOCurrencyRate.CurrencyRateID, BOCurrencyRate.EndOfDayRate, BOCurrencyRate.FromCurrencyCode, BOCurrencyRate.ModifiedDate, BOCurrencyRate.ToCurrencyCode);

			return model;
		}

		public virtual List<ApiCurrencyRateResponseModel> MapBOToModel(
			List<BOCurrencyRate> BOs)
		{
			List<ApiCurrencyRateResponseModel> response = new List<ApiCurrencyRateResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6df8d728e106ca7d2bbeee488beb39a4</Hash>
</Codenesium>*/
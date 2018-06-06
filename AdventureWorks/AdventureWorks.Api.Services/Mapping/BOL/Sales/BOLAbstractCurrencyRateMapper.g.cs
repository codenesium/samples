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

		public virtual ApiCurrencyRateResponseModel MapBOToModel(
			BOCurrencyRate boCurrencyRate)
		{
			var model = new ApiCurrencyRateResponseModel();

			model.SetProperties(boCurrencyRate.AverageRate, boCurrencyRate.CurrencyRateDate, boCurrencyRate.CurrencyRateID, boCurrencyRate.EndOfDayRate, boCurrencyRate.FromCurrencyCode, boCurrencyRate.ModifiedDate, boCurrencyRate.ToCurrencyCode);

			return model;
		}

		public virtual List<ApiCurrencyRateResponseModel> MapBOToModel(
			List<BOCurrencyRate> items)
		{
			List<ApiCurrencyRateResponseModel> response = new List<ApiCurrencyRateResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f7b2777d6da900113f81f61d5ae4006a</Hash>
</Codenesium>*/
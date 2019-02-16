using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCurrencyRateMapper
	{
		public virtual CurrencyRate MapModelToBO(
			int currencyRateID,
			ApiCurrencyRateServerRequestModel model
			)
		{
			CurrencyRate item = new CurrencyRate();
			item.SetProperties(
				currencyRateID,
				model.AverageRate,
				model.CurrencyRateDate,
				model.EndOfDayRate,
				model.FromCurrencyCode,
				model.ModifiedDate,
				model.ToCurrencyCode);
			return item;
		}

		public virtual ApiCurrencyRateServerResponseModel MapBOToModel(
			CurrencyRate item)
		{
			var model = new ApiCurrencyRateServerResponseModel();

			model.SetProperties(item.CurrencyRateID, item.AverageRate, item.CurrencyRateDate, item.EndOfDayRate, item.FromCurrencyCode, item.ModifiedDate, item.ToCurrencyCode);

			return model;
		}

		public virtual List<ApiCurrencyRateServerResponseModel> MapBOToModel(
			List<CurrencyRate> items)
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
    <Hash>32d660dbfde541509d2a5142928573cf</Hash>
</Codenesium>*/
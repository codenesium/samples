using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCurrencyRateMapper
	{
		public virtual CurrencyRate MapModelToEntity(
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

		public virtual ApiCurrencyRateServerResponseModel MapEntityToModel(
			CurrencyRate item)
		{
			var model = new ApiCurrencyRateServerResponseModel();

			model.SetProperties(item.CurrencyRateID,
			                    item.AverageRate,
			                    item.CurrencyRateDate,
			                    item.EndOfDayRate,
			                    item.FromCurrencyCode,
			                    item.ModifiedDate,
			                    item.ToCurrencyCode);
			if (item.FromCurrencyCodeNavigation != null)
			{
				var fromCurrencyCodeModel = new ApiCurrencyServerResponseModel();
				fromCurrencyCodeModel.SetProperties(
					item.FromCurrencyCodeNavigation.CurrencyCode,
					item.FromCurrencyCodeNavigation.ModifiedDate,
					item.FromCurrencyCodeNavigation.Name);

				model.SetFromCurrencyCodeNavigation(fromCurrencyCodeModel);
			}

			if (item.ToCurrencyCodeNavigation != null)
			{
				var toCurrencyCodeModel = new ApiCurrencyServerResponseModel();
				toCurrencyCodeModel.SetProperties(
					item.ToCurrencyCodeNavigation.CurrencyCode,
					item.ToCurrencyCodeNavigation.ModifiedDate,
					item.ToCurrencyCodeNavigation.Name);

				model.SetToCurrencyCodeNavigation(toCurrencyCodeModel);
			}

			return model;
		}

		public virtual List<ApiCurrencyRateServerResponseModel> MapEntityToModel(
			List<CurrencyRate> items)
		{
			List<ApiCurrencyRateServerResponseModel> response = new List<ApiCurrencyRateServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3d9b2e5d5f9c37ed11df5bf44d586d90</Hash>
</Codenesium>*/
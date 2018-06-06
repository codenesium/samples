using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCurrencyMapper
	{
		public virtual BOCurrency MapModelToBO(
			string currencyCode,
			ApiCurrencyRequestModel model
			)
		{
			BOCurrency boCurrency = new BOCurrency();

			boCurrency.SetProperties(
				currencyCode,
				model.ModifiedDate,
				model.Name);
			return boCurrency;
		}

		public virtual ApiCurrencyResponseModel MapBOToModel(
			BOCurrency boCurrency)
		{
			var model = new ApiCurrencyResponseModel();

			model.SetProperties(boCurrency.CurrencyCode, boCurrency.ModifiedDate, boCurrency.Name);

			return model;
		}

		public virtual List<ApiCurrencyResponseModel> MapBOToModel(
			List<BOCurrency> items)
		{
			List<ApiCurrencyResponseModel> response = new List<ApiCurrencyResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>20600cc4b90910bdd39685a113e98adb</Hash>
</Codenesium>*/
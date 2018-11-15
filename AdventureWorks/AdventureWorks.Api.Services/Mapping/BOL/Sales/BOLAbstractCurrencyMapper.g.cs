using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCurrencyMapper
	{
		public virtual BOCurrency MapModelToBO(
			string currencyCode,
			ApiCurrencyServerRequestModel model
			)
		{
			BOCurrency boCurrency = new BOCurrency();
			boCurrency.SetProperties(
				currencyCode,
				model.ModifiedDate,
				model.Name);
			return boCurrency;
		}

		public virtual ApiCurrencyServerResponseModel MapBOToModel(
			BOCurrency boCurrency)
		{
			var model = new ApiCurrencyServerResponseModel();

			model.SetProperties(boCurrency.CurrencyCode, boCurrency.ModifiedDate, boCurrency.Name);

			return model;
		}

		public virtual List<ApiCurrencyServerResponseModel> MapBOToModel(
			List<BOCurrency> items)
		{
			List<ApiCurrencyServerResponseModel> response = new List<ApiCurrencyServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>78cd712f690ecafc2754075d3a483588</Hash>
</Codenesium>*/
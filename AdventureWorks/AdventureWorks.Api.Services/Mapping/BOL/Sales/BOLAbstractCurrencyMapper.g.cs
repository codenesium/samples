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
			BOCurrency BOCurrency = new BOCurrency();

			BOCurrency.SetProperties(
				currencyCode,
				model.ModifiedDate,
				model.Name);
			return BOCurrency;
		}

		public virtual ApiCurrencyResponseModel MapBOToModel(
			BOCurrency BOCurrency)
		{
			if (BOCurrency == null)
			{
				return null;
			}

			var model = new ApiCurrencyResponseModel();

			model.SetProperties(BOCurrency.CurrencyCode, BOCurrency.ModifiedDate, BOCurrency.Name);

			return model;
		}

		public virtual List<ApiCurrencyResponseModel> MapBOToModel(
			List<BOCurrency> BOs)
		{
			List<ApiCurrencyResponseModel> response = new List<ApiCurrencyResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>949b3e9de1454dbc3798643fb6d1ff8e</Hash>
</Codenesium>*/
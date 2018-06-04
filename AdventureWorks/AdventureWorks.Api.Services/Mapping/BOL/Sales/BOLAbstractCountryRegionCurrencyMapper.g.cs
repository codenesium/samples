using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCountryRegionCurrencyMapper
	{
		public virtual BOCountryRegionCurrency MapModelToBO(
			string countryRegionCode,
			ApiCountryRegionCurrencyRequestModel model
			)
		{
			BOCountryRegionCurrency BOCountryRegionCurrency = new BOCountryRegionCurrency();

			BOCountryRegionCurrency.SetProperties(
				countryRegionCode,
				model.CurrencyCode,
				model.ModifiedDate);
			return BOCountryRegionCurrency;
		}

		public virtual ApiCountryRegionCurrencyResponseModel MapBOToModel(
			BOCountryRegionCurrency BOCountryRegionCurrency)
		{
			if (BOCountryRegionCurrency == null)
			{
				return null;
			}

			var model = new ApiCountryRegionCurrencyResponseModel();

			model.SetProperties(BOCountryRegionCurrency.CountryRegionCode, BOCountryRegionCurrency.CurrencyCode, BOCountryRegionCurrency.ModifiedDate);

			return model;
		}

		public virtual List<ApiCountryRegionCurrencyResponseModel> MapBOToModel(
			List<BOCountryRegionCurrency> BOs)
		{
			List<ApiCountryRegionCurrencyResponseModel> response = new List<ApiCountryRegionCurrencyResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>91fda97db9087fe0f2f10273cd3c73fd</Hash>
</Codenesium>*/
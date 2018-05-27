using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLCountryRegionCurrencyMapper
	{
		public virtual DTOCountryRegionCurrency MapModelToDTO(
			string countryRegionCode,
			ApiCountryRegionCurrencyRequestModel model
			)
		{
			DTOCountryRegionCurrency dtoCountryRegionCurrency = new DTOCountryRegionCurrency();

			dtoCountryRegionCurrency.SetProperties(
				countryRegionCode,
				model.CurrencyCode,
				model.ModifiedDate);
			return dtoCountryRegionCurrency;
		}

		public virtual ApiCountryRegionCurrencyResponseModel MapDTOToModel(
			DTOCountryRegionCurrency dtoCountryRegionCurrency)
		{
			if (dtoCountryRegionCurrency == null)
			{
				return null;
			}

			var model = new ApiCountryRegionCurrencyResponseModel();

			model.SetProperties(dtoCountryRegionCurrency.CountryRegionCode, dtoCountryRegionCurrency.CurrencyCode, dtoCountryRegionCurrency.ModifiedDate);

			return model;
		}

		public virtual List<ApiCountryRegionCurrencyResponseModel> MapDTOToModel(
			List<DTOCountryRegionCurrency> dtos)
		{
			List<ApiCountryRegionCurrencyResponseModel> response = new List<ApiCountryRegionCurrencyResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1a5d4acc17782ce7b4487f90095e24c3</Hash>
</Codenesium>*/
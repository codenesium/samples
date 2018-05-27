using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLCurrencyMapper
	{
		public virtual DTOCurrency MapModelToDTO(
			string currencyCode,
			ApiCurrencyRequestModel model
			)
		{
			DTOCurrency dtoCurrency = new DTOCurrency();

			dtoCurrency.SetProperties(
				currencyCode,
				model.ModifiedDate,
				model.Name);
			return dtoCurrency;
		}

		public virtual ApiCurrencyResponseModel MapDTOToModel(
			DTOCurrency dtoCurrency)
		{
			if (dtoCurrency == null)
			{
				return null;
			}

			var model = new ApiCurrencyResponseModel();

			model.SetProperties(dtoCurrency.CurrencyCode, dtoCurrency.ModifiedDate, dtoCurrency.Name);

			return model;
		}

		public virtual List<ApiCurrencyResponseModel> MapDTOToModel(
			List<DTOCurrency> dtos)
		{
			List<ApiCurrencyResponseModel> response = new List<ApiCurrencyResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2126eb4897475d9cd7516c91016b53fe</Hash>
</Codenesium>*/
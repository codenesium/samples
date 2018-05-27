using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLCurrencyRateMapper
	{
		public virtual DTOCurrencyRate MapModelToDTO(
			int currencyRateID,
			ApiCurrencyRateRequestModel model
			)
		{
			DTOCurrencyRate dtoCurrencyRate = new DTOCurrencyRate();

			dtoCurrencyRate.SetProperties(
				currencyRateID,
				model.AverageRate,
				model.CurrencyRateDate,
				model.EndOfDayRate,
				model.FromCurrencyCode,
				model.ModifiedDate,
				model.ToCurrencyCode);
			return dtoCurrencyRate;
		}

		public virtual ApiCurrencyRateResponseModel MapDTOToModel(
			DTOCurrencyRate dtoCurrencyRate)
		{
			if (dtoCurrencyRate == null)
			{
				return null;
			}

			var model = new ApiCurrencyRateResponseModel();

			model.SetProperties(dtoCurrencyRate.AverageRate, dtoCurrencyRate.CurrencyRateDate, dtoCurrencyRate.CurrencyRateID, dtoCurrencyRate.EndOfDayRate, dtoCurrencyRate.FromCurrencyCode, dtoCurrencyRate.ModifiedDate, dtoCurrencyRate.ToCurrencyCode);

			return model;
		}

		public virtual List<ApiCurrencyRateResponseModel> MapDTOToModel(
			List<DTOCurrencyRate> dtos)
		{
			List<ApiCurrencyRateResponseModel> response = new List<ApiCurrencyRateResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a86ffbecb2ecab82fd64ac0968ee112b</Hash>
</Codenesium>*/
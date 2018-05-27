using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALCurrencyRateMapper
	{
		public virtual void MapDTOToEF(
			int currencyRateID,
			DTOCurrencyRate dto,
			CurrencyRate efCurrencyRate)
		{
			efCurrencyRate.SetProperties(
				currencyRateID,
				dto.AverageRate,
				dto.CurrencyRateDate,
				dto.EndOfDayRate,
				dto.FromCurrencyCode,
				dto.ModifiedDate,
				dto.ToCurrencyCode);
		}

		public virtual DTOCurrencyRate MapEFToDTO(
			CurrencyRate ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOCurrencyRate();

			dto.SetProperties(
				ef.CurrencyRateID,
				ef.AverageRate,
				ef.CurrencyRateDate,
				ef.EndOfDayRate,
				ef.FromCurrencyCode,
				ef.ModifiedDate,
				ef.ToCurrencyCode);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>94680659a12393fe0d1aad6a9d5937cc</Hash>
</Codenesium>*/
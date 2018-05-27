using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALCountryRegionCurrencyMapper
	{
		public virtual void MapDTOToEF(
			string countryRegionCode,
			DTOCountryRegionCurrency dto,
			CountryRegionCurrency efCountryRegionCurrency)
		{
			efCountryRegionCurrency.SetProperties(
				countryRegionCode,
				dto.CurrencyCode,
				dto.ModifiedDate);
		}

		public virtual DTOCountryRegionCurrency MapEFToDTO(
			CountryRegionCurrency ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOCountryRegionCurrency();

			dto.SetProperties(
				ef.CountryRegionCode,
				ef.CurrencyCode,
				ef.ModifiedDate);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>a180f517f0278a4558b7fd051d33ae11</Hash>
</Codenesium>*/
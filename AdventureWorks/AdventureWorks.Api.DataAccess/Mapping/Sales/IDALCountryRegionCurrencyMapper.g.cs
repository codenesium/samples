using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALCountryRegionCurrencyMapper
	{
		void MapDTOToEF(
			string countryRegionCode,
			DTOCountryRegionCurrency dto,
			CountryRegionCurrency efCountryRegionCurrency);

		DTOCountryRegionCurrency MapEFToDTO(
			CountryRegionCurrency efCountryRegionCurrency);
	}
}

/*<Codenesium>
    <Hash>7a860c524cf88d60f58a4c18c411b338</Hash>
</Codenesium>*/
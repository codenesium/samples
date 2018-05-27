using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALCountryRegionMapper
	{
		void MapDTOToEF(
			string countryRegionCode,
			DTOCountryRegion dto,
			CountryRegion efCountryRegion);

		DTOCountryRegion MapEFToDTO(
			CountryRegion efCountryRegion);
	}
}

/*<Codenesium>
    <Hash>dab9d9ccbfe2e034e3e268592037d87d</Hash>
</Codenesium>*/
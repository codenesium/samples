using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALCountryRegionMapper
	{
		public virtual void MapDTOToEF(
			string countryRegionCode,
			DTOCountryRegion dto,
			CountryRegion efCountryRegion)
		{
			efCountryRegion.SetProperties(
				countryRegionCode,
				dto.ModifiedDate,
				dto.Name);
		}

		public virtual DTOCountryRegion MapEFToDTO(
			CountryRegion ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOCountryRegion();

			dto.SetProperties(
				ef.CountryRegionCode,
				ef.ModifiedDate,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>ee8f026224e0569f75aac96d904c9626</Hash>
</Codenesium>*/
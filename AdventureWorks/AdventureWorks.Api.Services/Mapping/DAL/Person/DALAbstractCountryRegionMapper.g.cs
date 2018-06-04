using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCountryRegionMapper
	{
		public virtual CountryRegion MapBOToEF(
			BOCountryRegion bo)
		{
			CountryRegion efCountryRegion = new CountryRegion ();

			efCountryRegion.SetProperties(
				bo.CountryRegionCode,
				bo.ModifiedDate,
				bo.Name);
			return efCountryRegion;
		}

		public virtual BOCountryRegion MapEFToBO(
			CountryRegion ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOCountryRegion();

			bo.SetProperties(
				ef.CountryRegionCode,
				ef.ModifiedDate,
				ef.Name);
			return bo;
		}

		public virtual List<BOCountryRegion> MapEFToBO(
			List<CountryRegion> records)
		{
			List<BOCountryRegion> response = new List<BOCountryRegion>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>29b745d2c4f57a350f3b708d5d7e64c5</Hash>
</Codenesium>*/
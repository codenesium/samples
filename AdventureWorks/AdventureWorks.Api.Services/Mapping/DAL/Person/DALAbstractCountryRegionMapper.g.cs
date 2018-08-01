using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractCountryRegionMapper
	{
		public virtual CountryRegion MapBOToEF(
			BOCountryRegion bo)
		{
			CountryRegion efCountryRegion = new CountryRegion();
			efCountryRegion.SetProperties(
				bo.CountryRegionCode,
				bo.ModifiedDate,
				bo.Name);
			return efCountryRegion;
		}

		public virtual BOCountryRegion MapEFToBO(
			CountryRegion ef)
		{
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
    <Hash>81b765c4fc9d8403ebb16a7c23ffeac7</Hash>
</Codenesium>*/
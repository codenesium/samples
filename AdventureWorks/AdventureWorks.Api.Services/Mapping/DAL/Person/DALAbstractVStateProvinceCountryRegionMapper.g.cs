using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractVStateProvinceCountryRegionMapper
	{
		public virtual VStateProvinceCountryRegion MapBOToEF(
			BOVStateProvinceCountryRegion bo)
		{
			VStateProvinceCountryRegion efVStateProvinceCountryRegion = new VStateProvinceCountryRegion();
			efVStateProvinceCountryRegion.SetProperties(
				bo.CountryRegionCode,
				bo.CountryRegionName,
				bo.IsOnlyStateProvinceFlag,
				bo.StateProvinceCode,
				bo.StateProvinceID,
				bo.StateProvinceName,
				bo.TerritoryID);
			return efVStateProvinceCountryRegion;
		}

		public virtual BOVStateProvinceCountryRegion MapEFToBO(
			VStateProvinceCountryRegion ef)
		{
			var bo = new BOVStateProvinceCountryRegion();

			bo.SetProperties(
				ef.StateProvinceID,
				ef.CountryRegionCode,
				ef.CountryRegionName,
				ef.IsOnlyStateProvinceFlag,
				ef.StateProvinceCode,
				ef.StateProvinceName,
				ef.TerritoryID);
			return bo;
		}

		public virtual List<BOVStateProvinceCountryRegion> MapEFToBO(
			List<VStateProvinceCountryRegion> records)
		{
			List<BOVStateProvinceCountryRegion> response = new List<BOVStateProvinceCountryRegion>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>260901fc98ab1089b90035bad04a40b7</Hash>
</Codenesium>*/
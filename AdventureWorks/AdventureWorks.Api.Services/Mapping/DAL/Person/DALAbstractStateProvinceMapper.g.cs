using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractStateProvinceMapper
	{
		public virtual StateProvince MapBOToEF(
			BOStateProvince bo)
		{
			StateProvince efStateProvince = new StateProvince();
			efStateProvince.SetProperties(
				bo.CountryRegionCode,
				bo.IsOnlyStateProvinceFlag,
				bo.ModifiedDate,
				bo.Name,
				bo.Rowguid,
				bo.StateProvinceCode,
				bo.StateProvinceID,
				bo.TerritoryID);
			return efStateProvince;
		}

		public virtual BOStateProvince MapEFToBO(
			StateProvince ef)
		{
			var bo = new BOStateProvince();

			bo.SetProperties(
				ef.StateProvinceID,
				ef.CountryRegionCode,
				ef.IsOnlyStateProvinceFlag,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid,
				ef.StateProvinceCode,
				ef.TerritoryID);
			return bo;
		}

		public virtual List<BOStateProvince> MapEFToBO(
			List<StateProvince> records)
		{
			List<BOStateProvince> response = new List<BOStateProvince>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3e9c7afe99f0eee4c98868e576159461</Hash>
</Codenesium>*/
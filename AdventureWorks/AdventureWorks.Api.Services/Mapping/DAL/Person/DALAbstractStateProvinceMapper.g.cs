using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALStateProvinceMapper
	{
		public virtual StateProvince MapBOToEF(
			BOStateProvince bo)
		{
			StateProvince efStateProvince = new StateProvince ();

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
			if (ef == null)
			{
				return null;
			}

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
    <Hash>4225963a38474574ad01fced7b167c4f</Hash>
</Codenesium>*/
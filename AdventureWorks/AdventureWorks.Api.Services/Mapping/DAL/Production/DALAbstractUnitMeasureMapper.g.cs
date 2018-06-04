using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALUnitMeasureMapper
	{
		public virtual UnitMeasure MapBOToEF(
			BOUnitMeasure bo)
		{
			UnitMeasure efUnitMeasure = new UnitMeasure ();

			efUnitMeasure.SetProperties(
				bo.ModifiedDate,
				bo.Name,
				bo.UnitMeasureCode);
			return efUnitMeasure;
		}

		public virtual BOUnitMeasure MapEFToBO(
			UnitMeasure ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOUnitMeasure();

			bo.SetProperties(
				ef.UnitMeasureCode,
				ef.ModifiedDate,
				ef.Name);
			return bo;
		}

		public virtual List<BOUnitMeasure> MapEFToBO(
			List<UnitMeasure> records)
		{
			List<BOUnitMeasure> response = new List<BOUnitMeasure>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c63d0f916752e64877ca34baf2a049f0</Hash>
</Codenesium>*/
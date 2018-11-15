using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractUnitMeasureMapper
	{
		public virtual UnitMeasure MapBOToEF(
			BOUnitMeasure bo)
		{
			UnitMeasure efUnitMeasure = new UnitMeasure();
			efUnitMeasure.SetProperties(
				bo.ModifiedDate,
				bo.Name,
				bo.UnitMeasureCode);
			return efUnitMeasure;
		}

		public virtual BOUnitMeasure MapEFToBO(
			UnitMeasure ef)
		{
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
    <Hash>50258144d068bd9245e1773e7b6ed1a2</Hash>
</Codenesium>*/
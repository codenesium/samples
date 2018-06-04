using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALUnitMeasureMapper
	{
		UnitMeasure MapBOToEF(
			BOUnitMeasure bo);

		BOUnitMeasure MapEFToBO(
			UnitMeasure efUnitMeasure);

		List<BOUnitMeasure> MapEFToBO(
			List<UnitMeasure> records);
	}
}

/*<Codenesium>
    <Hash>c25bcd91a720bb13366ef5934f883cdb</Hash>
</Codenesium>*/
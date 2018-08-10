using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALUnitMeasureMapper
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
    <Hash>2b9a038f5908f76eddcca4b8b4b8e4e2</Hash>
</Codenesium>*/
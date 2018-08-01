using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>a83bf393a8763a03e7a244ae63501db7</Hash>
</Codenesium>*/
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
    <Hash>b73fa31b17e7124ab854f206773c52b3</Hash>
</Codenesium>*/
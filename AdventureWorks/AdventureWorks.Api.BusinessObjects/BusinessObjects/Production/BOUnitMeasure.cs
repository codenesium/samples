using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOUnitMeasure: AbstractBOUnitMeasure, IBOUnitMeasure
	{
		public BOUnitMeasure(
			ILogger<UnitMeasureRepository> logger,
			IUnitMeasureRepository unitMeasureRepository,
			IUnitMeasureModelValidator unitMeasureModelValidator)
			: base(logger, unitMeasureRepository, unitMeasureModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>b56c47ff1b05a86d977ea0914098a6a1</Hash>
</Codenesium>*/
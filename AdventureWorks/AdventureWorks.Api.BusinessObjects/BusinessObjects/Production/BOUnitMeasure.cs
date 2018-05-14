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
			IApiUnitMeasureModelValidator unitMeasureModelValidator)
			: base(logger, unitMeasureRepository, unitMeasureModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>8bd83f17f33c46a67ed05f7e368974a5</Hash>
</Codenesium>*/
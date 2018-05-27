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
			IApiUnitMeasureRequestModelValidator unitMeasureModelValidator,
			IBOLUnitMeasureMapper unitMeasureMapper)
			: base(logger, unitMeasureRepository, unitMeasureModelValidator, unitMeasureMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>0c5b75aeedd77e7b401acbead5480435</Hash>
</Codenesium>*/
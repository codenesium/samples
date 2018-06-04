using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class UnitMeasureService: AbstractUnitMeasureService, IUnitMeasureService
	{
		public UnitMeasureService(
			ILogger<UnitMeasureRepository> logger,
			IUnitMeasureRepository unitMeasureRepository,
			IApiUnitMeasureRequestModelValidator unitMeasureModelValidator,
			IBOLUnitMeasureMapper BOLunitMeasureMapper,
			IDALUnitMeasureMapper DALunitMeasureMapper)
			: base(logger, unitMeasureRepository,
			       unitMeasureModelValidator,
			       BOLunitMeasureMapper,
			       DALunitMeasureMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>0ce313d3939d5921d1768e5538b9163d</Hash>
</Codenesium>*/
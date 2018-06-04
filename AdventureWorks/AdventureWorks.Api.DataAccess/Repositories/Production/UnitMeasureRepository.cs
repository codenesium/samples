using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class UnitMeasureRepository: AbstractUnitMeasureRepository, IUnitMeasureRepository
	{
		public UnitMeasureRepository(
			ILogger<UnitMeasureRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>c8f61a9222ec521f1633ab34356c7f45</Hash>
</Codenesium>*/
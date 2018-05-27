using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class UnitMeasureRepository: AbstractUnitMeasureRepository, IUnitMeasureRepository
	{
		public UnitMeasureRepository(
			IDALUnitMeasureMapper mapper,
			ILogger<UnitMeasureRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>1757869f88fc6bd241374e8cd32a7f08</Hash>
</Codenesium>*/
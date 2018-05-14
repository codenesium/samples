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
			IObjectMapper mapper,
			ILogger<UnitMeasureRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>adf12f870adee6d2cc12efbd28611d4d</Hash>
</Codenesium>*/
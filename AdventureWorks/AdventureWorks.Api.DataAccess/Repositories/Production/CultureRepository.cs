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
	public class CultureRepository: AbstractCultureRepository, ICultureRepository
	{
		public CultureRepository(
			IObjectMapper mapper,
			ILogger<CultureRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>920364743d3850b8f7ed6132633482f1</Hash>
</Codenesium>*/
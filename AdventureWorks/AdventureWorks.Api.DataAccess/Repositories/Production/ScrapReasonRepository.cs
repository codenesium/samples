using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public class ScrapReasonRepository: AbstractScrapReasonRepository, IScrapReasonRepository
	{
		public ScrapReasonRepository(
			ILogger<ScrapReasonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>a3147d1892e86a7e10d1a47309e8307e</Hash>
</Codenesium>*/
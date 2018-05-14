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
	public class ScrapReasonRepository: AbstractScrapReasonRepository, IScrapReasonRepository
	{
		public ScrapReasonRepository(
			IObjectMapper mapper,
			ILogger<ScrapReasonRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>50b860e97299c66caa9a597ea39ff358</Hash>
</Codenesium>*/
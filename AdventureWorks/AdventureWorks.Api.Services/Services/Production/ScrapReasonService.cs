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
	public class ScrapReasonService: AbstractScrapReasonService, IScrapReasonService
	{
		public ScrapReasonService(
			ILogger<ScrapReasonRepository> logger,
			IScrapReasonRepository scrapReasonRepository,
			IApiScrapReasonRequestModelValidator scrapReasonModelValidator,
			IBOLScrapReasonMapper BOLscrapReasonMapper,
			IDALScrapReasonMapper DALscrapReasonMapper)
			: base(logger, scrapReasonRepository,
			       scrapReasonModelValidator,
			       BOLscrapReasonMapper,
			       DALscrapReasonMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>f074e8cc42db998d2cb92934539e9b10</Hash>
</Codenesium>*/
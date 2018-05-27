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
	public class BOScrapReason: AbstractBOScrapReason, IBOScrapReason
	{
		public BOScrapReason(
			ILogger<ScrapReasonRepository> logger,
			IScrapReasonRepository scrapReasonRepository,
			IApiScrapReasonRequestModelValidator scrapReasonModelValidator,
			IBOLScrapReasonMapper scrapReasonMapper)
			: base(logger, scrapReasonRepository, scrapReasonModelValidator, scrapReasonMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>7c92850285fae6c6729316610a50a81b</Hash>
</Codenesium>*/
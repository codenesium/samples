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
			IApiScrapReasonModelValidator scrapReasonModelValidator)
			: base(logger, scrapReasonRepository, scrapReasonModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f0c7913ca8322b9ee5ef1c1139cf9bb1</Hash>
</Codenesium>*/
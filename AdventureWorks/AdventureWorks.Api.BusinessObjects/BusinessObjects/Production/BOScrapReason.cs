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
			IScrapReasonModelValidator scrapReasonModelValidator)
			: base(logger, scrapReasonRepository, scrapReasonModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>be08dae3bdef5d9766484ce63cb11174</Hash>
</Codenesium>*/
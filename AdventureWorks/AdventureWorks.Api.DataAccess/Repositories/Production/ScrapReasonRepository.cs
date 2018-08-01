using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial class ScrapReasonRepository : AbstractScrapReasonRepository, IScrapReasonRepository
	{
		public ScrapReasonRepository(
			ILogger<ScrapReasonRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>936c01002f87ca5304840cb1c21c9e5d</Hash>
</Codenesium>*/
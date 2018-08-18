using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>2378c24ef2301d85653a6a68e3a785c5</Hash>
</Codenesium>*/
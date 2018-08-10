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
    <Hash>6a1ebd63ae9e677532efeeaffbe355ba</Hash>
</Codenesium>*/
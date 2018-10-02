using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public partial class QuoteTweetRepository : AbstractQuoteTweetRepository, IQuoteTweetRepository
	{
		public QuoteTweetRepository(
			ILogger<QuoteTweetRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>160eb9f55bfa63ab2b7c8b78dcc3be00</Hash>
</Codenesium>*/
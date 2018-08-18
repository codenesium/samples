using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial class LinkLogRepository : AbstractLinkLogRepository, ILinkLogRepository
	{
		public LinkLogRepository(
			ILogger<LinkLogRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>26bf8c007bc9d1b686785c9f91769309</Hash>
</Codenesium>*/
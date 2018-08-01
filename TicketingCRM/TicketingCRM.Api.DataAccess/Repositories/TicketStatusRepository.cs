using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial class TicketStatusRepository : AbstractTicketStatusRepository, ITicketStatusRepository
	{
		public TicketStatusRepository(
			ILogger<TicketStatusRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>40b2fb2741583d08d46653a9c8413d07</Hash>
</Codenesium>*/
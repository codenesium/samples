using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial class TicketRepository : AbstractTicketRepository, ITicketRepository
	{
		public TicketRepository(
			ILogger<TicketRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bbc7820cf5a6fdb301bbbfb2b4a9e254</Hash>
</Codenesium>*/
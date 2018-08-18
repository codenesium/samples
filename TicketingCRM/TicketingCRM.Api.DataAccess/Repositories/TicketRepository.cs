using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>e0502e9b13ae215c0a3a52c1f556156c</Hash>
</Codenesium>*/
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
    <Hash>1427a69574783993b7ffa15fe58094a3</Hash>
</Codenesium>*/
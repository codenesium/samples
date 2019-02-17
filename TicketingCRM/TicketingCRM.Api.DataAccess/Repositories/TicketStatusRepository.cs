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
    <Hash>2c6a591a0457eed5f7f69951fa77dde5</Hash>
</Codenesium>*/
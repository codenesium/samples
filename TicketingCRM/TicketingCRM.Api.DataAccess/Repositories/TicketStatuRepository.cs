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
	public partial class TicketStatuRepository : AbstractTicketStatuRepository, ITicketStatuRepository
	{
		public TicketStatuRepository(
			ILogger<TicketStatuRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>28e96dbbf4d14822cff0c2f97c8a97f3</Hash>
</Codenesium>*/
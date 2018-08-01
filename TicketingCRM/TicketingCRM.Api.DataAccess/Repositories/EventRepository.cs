using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
	public partial class EventRepository : AbstractEventRepository, IEventRepository
	{
		public EventRepository(
			ILogger<EventRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>df11c91ebb85717c1b136064f1bf95a0</Hash>
</Codenesium>*/
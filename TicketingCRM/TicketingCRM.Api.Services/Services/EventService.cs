using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class EventService : AbstractEventService, IEventService
	{
		public EventService(
			ILogger<IEventRepository> logger,
			IEventRepository eventRepository,
			IApiEventRequestModelValidator eventModelValidator,
			IBOLEventMapper boleventMapper,
			IDALEventMapper daleventMapper
			)
			: base(logger,
			       eventRepository,
			       eventModelValidator,
			       boleventMapper,
			       daleventMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>04849e254a491df7bfafb654c3c3b12e</Hash>
</Codenesium>*/
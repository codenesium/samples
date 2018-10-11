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
			IDALEventMapper daleventMapper)
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
    <Hash>87594012df6c7af40a9c07bc2c1b2abd</Hash>
</Codenesium>*/
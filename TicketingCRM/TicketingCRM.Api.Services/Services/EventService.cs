using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class EventService: AbstractEventService, IEventService
        {
                public EventService(
                        ILogger<EventRepository> logger,
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
    <Hash>6b45b9dd2dc719de6d6489f0a35865fc</Hash>
</Codenesium>*/
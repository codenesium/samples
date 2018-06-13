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
                        IDALEventMapper daleventMapper

                        )
                        : base(logger,
                               eventRepository,
                               eventModelValidator,
                               boleventMapper,
                               daleventMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>e6e6db22b906cb4034bb538bb31a764e</Hash>
</Codenesium>*/
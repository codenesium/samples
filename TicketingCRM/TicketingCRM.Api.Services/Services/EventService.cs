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
                               daleventMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>71a90b51d6d924287124ec067c771c1e</Hash>
</Codenesium>*/
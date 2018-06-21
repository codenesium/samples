using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class EventRepository : AbstractEventRepository, IEventRepository
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
    <Hash>a87a5c8c06361d70b12e3c7b97165a75</Hash>
</Codenesium>*/
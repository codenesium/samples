using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
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
    <Hash>9b661b58c2280a8ce6b52b7e5ce5abfc</Hash>
</Codenesium>*/
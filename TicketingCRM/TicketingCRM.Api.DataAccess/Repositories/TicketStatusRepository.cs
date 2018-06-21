using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class TicketStatusRepository : AbstractTicketStatusRepository, ITicketStatusRepository
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
    <Hash>5d7b1e803993aed35d192a8ac14b6a1b</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class TicketRepository : AbstractTicketRepository, ITicketRepository
        {
                public TicketRepository(
                        ILogger<TicketRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>c0f135ca27a2c49bc2bd2f73967dc717</Hash>
</Codenesium>*/
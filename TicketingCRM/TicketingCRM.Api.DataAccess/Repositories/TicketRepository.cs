using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public partial class TicketRepository : AbstractTicketRepository, ITicketRepository
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
    <Hash>284ca31f7df07c00ab654111b6698b5a</Hash>
</Codenesium>*/
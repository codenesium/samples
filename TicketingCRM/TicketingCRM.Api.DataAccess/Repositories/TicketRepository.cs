using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>3cbcda0c45ea19a9f9dfe58a7677256c</Hash>
</Codenesium>*/
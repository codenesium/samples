using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class TicketRepository: AbstractTicketRepository, ITicketRepository
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
    <Hash>23544c51bcf55fcba40822a227cfb61f</Hash>
</Codenesium>*/
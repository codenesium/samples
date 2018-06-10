using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class TicketStatusRepository: AbstractTicketStatusRepository, ITicketStatusRepository
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
    <Hash>b9cbe85759927c5dc835c4022e5ae427</Hash>
</Codenesium>*/
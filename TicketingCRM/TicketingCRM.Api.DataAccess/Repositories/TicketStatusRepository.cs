using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public partial class TicketStatusRepository : AbstractTicketStatusRepository, ITicketStatusRepository
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
    <Hash>65cd44e3844fde3d6fe0f5338af841f1</Hash>
</Codenesium>*/
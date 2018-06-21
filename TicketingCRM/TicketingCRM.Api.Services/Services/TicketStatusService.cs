using Codenesium.DataConversionExtensions;
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
        public class TicketStatusService : AbstractTicketStatusService, ITicketStatusService
        {
                public TicketStatusService(
                        ILogger<ITicketStatusRepository> logger,
                        ITicketStatusRepository ticketStatusRepository,
                        IApiTicketStatusRequestModelValidator ticketStatusModelValidator,
                        IBOLTicketStatusMapper bolticketStatusMapper,
                        IDALTicketStatusMapper dalticketStatusMapper,
                        IBOLTicketMapper bolTicketMapper,
                        IDALTicketMapper dalTicketMapper
                        )
                        : base(logger,
                               ticketStatusRepository,
                               ticketStatusModelValidator,
                               bolticketStatusMapper,
                               dalticketStatusMapper,
                               bolTicketMapper,
                               dalTicketMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>07c6c0e2a3596c882ae974034caad201</Hash>
</Codenesium>*/
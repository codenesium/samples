using Codenesium.DataConversionExtensions.AspNetCore;
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
        public class TicketStatusService: AbstractTicketStatusService, ITicketStatusService
        {
                public TicketStatusService(
                        ILogger<TicketStatusRepository> logger,
                        ITicketStatusRepository ticketStatusRepository,
                        IApiTicketStatusRequestModelValidator ticketStatusModelValidator,
                        IBOLTicketStatusMapper bolticketStatusMapper,
                        IDALTicketStatusMapper dalticketStatusMapper)
                        : base(logger,
                               ticketStatusRepository,
                               ticketStatusModelValidator,
                               bolticketStatusMapper,
                               dalticketStatusMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>6b147a747a2c32fd14554a500e5c64bb</Hash>
</Codenesium>*/
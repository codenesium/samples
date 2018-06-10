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
        public class TicketService: AbstractTicketService, ITicketService
        {
                public TicketService(
                        ILogger<TicketRepository> logger,
                        ITicketRepository ticketRepository,
                        IApiTicketRequestModelValidator ticketModelValidator,
                        IBOLTicketMapper bolticketMapper,
                        IDALTicketMapper dalticketMapper)
                        : base(logger,
                               ticketRepository,
                               ticketModelValidator,
                               bolticketMapper,
                               dalticketMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a9fdc1aaaa20fd98c83e43f163a6c16d</Hash>
</Codenesium>*/
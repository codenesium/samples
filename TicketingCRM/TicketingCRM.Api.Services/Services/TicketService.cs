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
        public class TicketService : AbstractTicketService, ITicketService
        {
                public TicketService(
                        ILogger<ITicketRepository> logger,
                        ITicketRepository ticketRepository,
                        IApiTicketRequestModelValidator ticketModelValidator,
                        IBOLTicketMapper bolticketMapper,
                        IDALTicketMapper dalticketMapper,
                        IBOLSaleTicketsMapper bolSaleTicketsMapper,
                        IDALSaleTicketsMapper dalSaleTicketsMapper
                        )
                        : base(logger,
                               ticketRepository,
                               ticketModelValidator,
                               bolticketMapper,
                               dalticketMapper,
                               bolSaleTicketsMapper,
                               dalSaleTicketsMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>3c66358a2a4307af5d6f07063e50748d</Hash>
</Codenesium>*/
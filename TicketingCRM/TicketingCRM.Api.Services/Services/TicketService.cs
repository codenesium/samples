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
                        IDALTicketMapper dalticketMapper
                        ,
                        IBOLSaleTicketsMapper bolSaleTicketsMapper,
                        IDALSaleTicketsMapper dalSaleTicketsMapper

                        )
                        : base(logger,
                               ticketRepository,
                               ticketModelValidator,
                               bolticketMapper,
                               dalticketMapper
                               ,
                               bolSaleTicketsMapper,
                               dalSaleTicketsMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>5b546a268be6281dbce8dfbdd1dee7e9</Hash>
</Codenesium>*/
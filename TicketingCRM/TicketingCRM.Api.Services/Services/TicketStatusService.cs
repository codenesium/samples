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
                        IDALTicketStatusMapper dalticketStatusMapper
                        ,
                        IBOLTicketMapper bolTicketMapper,
                        IDALTicketMapper dalTicketMapper

                        )
                        : base(logger,
                               ticketStatusRepository,
                               ticketStatusModelValidator,
                               bolticketStatusMapper,
                               dalticketStatusMapper
                               ,
                               bolTicketMapper,
                               dalTicketMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>cf529551199c80d1f4ec50244d1f6cc1</Hash>
</Codenesium>*/
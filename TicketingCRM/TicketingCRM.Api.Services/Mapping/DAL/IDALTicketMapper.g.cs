using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IDALTicketMapper
        {
                Ticket MapBOToEF(
                        BOTicket bo);

                BOTicket MapEFToBO(
                        Ticket efTicket);

                List<BOTicket> MapEFToBO(
                        List<Ticket> records);
        }
}

/*<Codenesium>
    <Hash>579e84a34b1642ea64f0b67a9b80d06f</Hash>
</Codenesium>*/
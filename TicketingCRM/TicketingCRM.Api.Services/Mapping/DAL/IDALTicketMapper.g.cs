using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    <Hash>40631f14d1d4a00bb93df7e394e312c7</Hash>
</Codenesium>*/
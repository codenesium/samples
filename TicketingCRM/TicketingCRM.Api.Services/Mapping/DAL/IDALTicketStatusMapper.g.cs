using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IDALTicketStatusMapper
        {
                TicketStatus MapBOToEF(
                        BOTicketStatus bo);

                BOTicketStatus MapEFToBO(
                        TicketStatus efTicketStatus);

                List<BOTicketStatus> MapEFToBO(
                        List<TicketStatus> records);
        }
}

/*<Codenesium>
    <Hash>434ff09dbb0006d5005463849fdba66a</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    <Hash>d42f7f310d45c32be3eb7f5c102bedff</Hash>
</Codenesium>*/
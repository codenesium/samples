using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IDALEventMapper
        {
                Event MapBOToEF(
                        BOEvent bo);

                BOEvent MapEFToBO(
                        Event efEvent);

                List<BOEvent> MapEFToBO(
                        List<Event> records);
        }
}

/*<Codenesium>
    <Hash>d07d636e6e6da649406f7a03c6837ee3</Hash>
</Codenesium>*/
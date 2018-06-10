using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    <Hash>5b1dc9e084e049fccc249ac5d5975a1b</Hash>
</Codenesium>*/
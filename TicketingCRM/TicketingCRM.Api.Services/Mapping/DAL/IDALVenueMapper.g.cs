using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IDALVenueMapper
        {
                Venue MapBOToEF(
                        BOVenue bo);

                BOVenue MapEFToBO(
                        Venue efVenue);

                List<BOVenue> MapEFToBO(
                        List<Venue> records);
        }
}

/*<Codenesium>
    <Hash>4d399870010b4d5ee93656367f963981</Hash>
</Codenesium>*/
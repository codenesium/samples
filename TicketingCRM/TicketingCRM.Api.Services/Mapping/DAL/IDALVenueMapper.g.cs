using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    <Hash>e048f182e617103d2cefa1f44aa99aa9</Hash>
</Codenesium>*/
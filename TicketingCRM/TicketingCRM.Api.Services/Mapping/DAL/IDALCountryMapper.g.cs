using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IDALCountryMapper
        {
                Country MapBOToEF(
                        BOCountry bo);

                BOCountry MapEFToBO(
                        Country efCountry);

                List<BOCountry> MapEFToBO(
                        List<Country> records);
        }
}

/*<Codenesium>
    <Hash>e6d3fbda34370d956e1b81d74c5e46c9</Hash>
</Codenesium>*/
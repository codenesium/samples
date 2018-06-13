using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    <Hash>e3e0112e932cff9b31b597c153aff3ef</Hash>
</Codenesium>*/
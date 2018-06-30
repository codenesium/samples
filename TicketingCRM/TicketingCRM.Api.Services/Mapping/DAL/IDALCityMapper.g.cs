using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IDALCityMapper
        {
                City MapBOToEF(
                        BOCity bo);

                BOCity MapEFToBO(
                        City efCity);

                List<BOCity> MapEFToBO(
                        List<City> records);
        }
}

/*<Codenesium>
    <Hash>cbf9549d3ef48f112ece9b86e8833e4c</Hash>
</Codenesium>*/
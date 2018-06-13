using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    <Hash>5f4a708e1ad339ac8cf51331817f55dc</Hash>
</Codenesium>*/
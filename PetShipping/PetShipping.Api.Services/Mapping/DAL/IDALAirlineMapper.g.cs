using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IDALAirlineMapper
        {
                Airline MapBOToEF(
                        BOAirline bo);

                BOAirline MapEFToBO(
                        Airline efAirline);

                List<BOAirline> MapEFToBO(
                        List<Airline> records);
        }
}

/*<Codenesium>
    <Hash>1b1ba7c71ebca4ec0d0c8a9e9c24ae24</Hash>
</Codenesium>*/
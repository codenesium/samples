using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>9169ef21bad7d899240f09f8de54ecce</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IDALAirTransportMapper
        {
                AirTransport MapBOToEF(
                        BOAirTransport bo);

                BOAirTransport MapEFToBO(
                        AirTransport efAirTransport);

                List<BOAirTransport> MapEFToBO(
                        List<AirTransport> records);
        }
}

/*<Codenesium>
    <Hash>b71e9dfcc8d0d7ad89323f9d68d729f0</Hash>
</Codenesium>*/
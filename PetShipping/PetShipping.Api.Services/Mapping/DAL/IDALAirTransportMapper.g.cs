using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>2e1448c61b4a6c5ecab3217c57ace51d</Hash>
</Codenesium>*/
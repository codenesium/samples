using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IDALDestinationMapper
        {
                Destination MapBOToEF(
                        BODestination bo);

                BODestination MapEFToBO(
                        Destination efDestination);

                List<BODestination> MapEFToBO(
                        List<Destination> records);
        }
}

/*<Codenesium>
    <Hash>85e8f86eb0e4e6267fbe732c5ea92e55</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>703ca36943bc63456234c971073e8446</Hash>
</Codenesium>*/
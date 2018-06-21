using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IDALClientMapper
        {
                Client MapBOToEF(
                        BOClient bo);

                BOClient MapEFToBO(
                        Client efClient);

                List<BOClient> MapEFToBO(
                        List<Client> records);
        }
}

/*<Codenesium>
    <Hash>68f9a7c387535246a0ac95ecb90a927f</Hash>
</Codenesium>*/
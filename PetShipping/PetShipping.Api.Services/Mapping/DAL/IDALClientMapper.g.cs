using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>1d5ad693fa81130001c27f1f549f5c51</Hash>
</Codenesium>*/
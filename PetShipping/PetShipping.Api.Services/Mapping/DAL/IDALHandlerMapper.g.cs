using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IDALHandlerMapper
        {
                Handler MapBOToEF(
                        BOHandler bo);

                BOHandler MapEFToBO(
                        Handler efHandler);

                List<BOHandler> MapEFToBO(
                        List<Handler> records);
        }
}

/*<Codenesium>
    <Hash>432739fd3fe78f555cea9fdbb470998b</Hash>
</Codenesium>*/
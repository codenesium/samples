using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>41289da10104bb8aba381e3eed057592</Hash>
</Codenesium>*/
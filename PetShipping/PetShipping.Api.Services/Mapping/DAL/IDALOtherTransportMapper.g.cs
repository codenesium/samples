using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IDALOtherTransportMapper
        {
                OtherTransport MapBOToEF(
                        BOOtherTransport bo);

                BOOtherTransport MapEFToBO(
                        OtherTransport efOtherTransport);

                List<BOOtherTransport> MapEFToBO(
                        List<OtherTransport> records);
        }
}

/*<Codenesium>
    <Hash>2eeea15014de04a0fa0f93b1e36065b5</Hash>
</Codenesium>*/
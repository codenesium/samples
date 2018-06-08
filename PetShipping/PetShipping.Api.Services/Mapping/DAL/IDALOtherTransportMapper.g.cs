using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>c4363ac64a814effafeb84d3d94e2508</Hash>
</Codenesium>*/
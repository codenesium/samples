using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IDALStudioMapper
        {
                Studio MapBOToEF(
                        BOStudio bo);

                BOStudio MapEFToBO(
                        Studio efStudio);

                List<BOStudio> MapEFToBO(
                        List<Studio> records);
        }
}

/*<Codenesium>
    <Hash>46b17b2111a6ba48fd3f8dd9fcc98d0f</Hash>
</Codenesium>*/
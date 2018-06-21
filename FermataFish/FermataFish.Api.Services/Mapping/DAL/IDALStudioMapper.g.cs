using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>d1b5550f447b2cb2d05833323e55b9cd</Hash>
</Codenesium>*/
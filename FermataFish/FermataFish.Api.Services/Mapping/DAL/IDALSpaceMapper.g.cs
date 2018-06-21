using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IDALSpaceMapper
        {
                Space MapBOToEF(
                        BOSpace bo);

                BOSpace MapEFToBO(
                        Space efSpace);

                List<BOSpace> MapEFToBO(
                        List<Space> records);
        }
}

/*<Codenesium>
    <Hash>2da4430c2680cb325ae0260c2b291694</Hash>
</Codenesium>*/
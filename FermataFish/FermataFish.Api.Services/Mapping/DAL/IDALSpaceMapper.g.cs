using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>6491e60ffe4e0b47460def5ea826dc49</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IDALSpaceFeatureMapper
        {
                SpaceFeature MapBOToEF(
                        BOSpaceFeature bo);

                BOSpaceFeature MapEFToBO(
                        SpaceFeature efSpaceFeature);

                List<BOSpaceFeature> MapEFToBO(
                        List<SpaceFeature> records);
        }
}

/*<Codenesium>
    <Hash>223705a7fc306430f86cc21a168d573c</Hash>
</Codenesium>*/
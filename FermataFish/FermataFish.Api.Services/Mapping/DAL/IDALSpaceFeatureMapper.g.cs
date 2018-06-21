using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>208e4ce8df34cebe97ed074bca3e6c05</Hash>
</Codenesium>*/
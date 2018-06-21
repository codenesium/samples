using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IDALSpaceXSpaceFeatureMapper
        {
                SpaceXSpaceFeature MapBOToEF(
                        BOSpaceXSpaceFeature bo);

                BOSpaceXSpaceFeature MapEFToBO(
                        SpaceXSpaceFeature efSpaceXSpaceFeature);

                List<BOSpaceXSpaceFeature> MapEFToBO(
                        List<SpaceXSpaceFeature> records);
        }
}

/*<Codenesium>
    <Hash>6011ae2396aff87d440ef0ffa5d66cb1</Hash>
</Codenesium>*/
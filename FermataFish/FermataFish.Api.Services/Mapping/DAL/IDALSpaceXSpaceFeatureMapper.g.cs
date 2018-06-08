using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>51de8fbe99a9b4b4e8c6662505d09dc6</Hash>
</Codenesium>*/
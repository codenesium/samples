using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class SpaceFeatureService: AbstractSpaceFeatureService, ISpaceFeatureService
        {
                public SpaceFeatureService(
                        ILogger<SpaceFeatureRepository> logger,
                        ISpaceFeatureRepository spaceFeatureRepository,
                        IApiSpaceFeatureRequestModelValidator spaceFeatureModelValidator,
                        IBOLSpaceFeatureMapper bolspaceFeatureMapper,
                        IDALSpaceFeatureMapper dalspaceFeatureMapper
                        ,
                        IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper,
                        IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper

                        )
                        : base(logger,
                               spaceFeatureRepository,
                               spaceFeatureModelValidator,
                               bolspaceFeatureMapper,
                               dalspaceFeatureMapper
                               ,
                               bolSpaceXSpaceFeatureMapper,
                               dalSpaceXSpaceFeatureMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>98ea6ca8fc1b8f488f4a8a02b5a60ffb</Hash>
</Codenesium>*/
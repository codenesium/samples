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
        public class SpaceXSpaceFeatureService: AbstractSpaceXSpaceFeatureService, ISpaceXSpaceFeatureService
        {
                public SpaceXSpaceFeatureService(
                        ILogger<SpaceXSpaceFeatureRepository> logger,
                        ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository,
                        IApiSpaceXSpaceFeatureRequestModelValidator spaceXSpaceFeatureModelValidator,
                        IBOLSpaceXSpaceFeatureMapper bolspaceXSpaceFeatureMapper,
                        IDALSpaceXSpaceFeatureMapper dalspaceXSpaceFeatureMapper

                        )
                        : base(logger,
                               spaceXSpaceFeatureRepository,
                               spaceXSpaceFeatureModelValidator,
                               bolspaceXSpaceFeatureMapper,
                               dalspaceXSpaceFeatureMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>d2cbe48760f1317776d465418b3d0c30</Hash>
</Codenesium>*/
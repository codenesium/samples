using Codenesium.DataConversionExtensions.AspNetCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Services
{
        public class SpaceFeatureService : AbstractSpaceFeatureService, ISpaceFeatureService
        {
                public SpaceFeatureService(
                        ILogger<ISpaceFeatureRepository> logger,
                        ISpaceFeatureRepository spaceFeatureRepository,
                        IApiSpaceFeatureRequestModelValidator spaceFeatureModelValidator,
                        IBOLSpaceFeatureMapper bolspaceFeatureMapper,
                        IDALSpaceFeatureMapper dalspaceFeatureMapper,
                        IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper,
                        IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper
                        )
                        : base(logger,
                               spaceFeatureRepository,
                               spaceFeatureModelValidator,
                               bolspaceFeatureMapper,
                               dalspaceFeatureMapper,
                               bolSpaceXSpaceFeatureMapper,
                               dalSpaceXSpaceFeatureMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9ff67a3db88feda0b9613d3a73e1dde6</Hash>
</Codenesium>*/
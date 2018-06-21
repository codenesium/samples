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
        public class SpaceService : AbstractSpaceService, ISpaceService
        {
                public SpaceService(
                        ILogger<ISpaceRepository> logger,
                        ISpaceRepository spaceRepository,
                        IApiSpaceRequestModelValidator spaceModelValidator,
                        IBOLSpaceMapper bolspaceMapper,
                        IDALSpaceMapper dalspaceMapper,
                        IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper,
                        IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper
                        )
                        : base(logger,
                               spaceRepository,
                               spaceModelValidator,
                               bolspaceMapper,
                               dalspaceMapper,
                               bolSpaceXSpaceFeatureMapper,
                               dalSpaceXSpaceFeatureMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9775828e9a7da4fec8c22a85e84a96ef</Hash>
</Codenesium>*/
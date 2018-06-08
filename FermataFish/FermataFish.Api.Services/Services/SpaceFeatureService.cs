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
                        IDALSpaceFeatureMapper dalspaceFeatureMapper)
                        : base(logger,
                               spaceFeatureRepository,
                               spaceFeatureModelValidator,
                               bolspaceFeatureMapper,
                               dalspaceFeatureMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>170d960671d6d8be77eedd47841beb10</Hash>
</Codenesium>*/
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
        public class SpaceXSpaceFeatureService : AbstractSpaceXSpaceFeatureService, ISpaceXSpaceFeatureService
        {
                public SpaceXSpaceFeatureService(
                        ILogger<ISpaceXSpaceFeatureRepository> logger,
                        ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository,
                        IApiSpaceXSpaceFeatureRequestModelValidator spaceXSpaceFeatureModelValidator,
                        IBOLSpaceXSpaceFeatureMapper bolspaceXSpaceFeatureMapper,
                        IDALSpaceXSpaceFeatureMapper dalspaceXSpaceFeatureMapper
                        )
                        : base(logger,
                               spaceXSpaceFeatureRepository,
                               spaceXSpaceFeatureModelValidator,
                               bolspaceXSpaceFeatureMapper,
                               dalspaceXSpaceFeatureMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>54a26de0972a653e41dc7b130f6bc161</Hash>
</Codenesium>*/
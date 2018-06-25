using Codenesium.DataConversionExtensions;
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
        public partial class SpaceFeatureService : AbstractSpaceFeatureService, ISpaceFeatureService
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
    <Hash>bcb8cc0daf7b0da84a72e5a50858526b</Hash>
</Codenesium>*/
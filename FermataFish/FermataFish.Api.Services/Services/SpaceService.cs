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
        public class SpaceService: AbstractSpaceService, ISpaceService
        {
                public SpaceService(
                        ILogger<SpaceRepository> logger,
                        ISpaceRepository spaceRepository,
                        IApiSpaceRequestModelValidator spaceModelValidator,
                        IBOLSpaceMapper bolspaceMapper,
                        IDALSpaceMapper dalspaceMapper
                        ,
                        IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper,
                        IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper

                        )
                        : base(logger,
                               spaceRepository,
                               spaceModelValidator,
                               bolspaceMapper,
                               dalspaceMapper
                               ,
                               bolSpaceXSpaceFeatureMapper,
                               dalSpaceXSpaceFeatureMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>a4ba9274881bac454b5e887af353c8ac</Hash>
</Codenesium>*/
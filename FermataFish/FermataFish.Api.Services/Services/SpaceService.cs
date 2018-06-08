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
                        IDALSpaceMapper dalspaceMapper)
                        : base(logger,
                               spaceRepository,
                               spaceModelValidator,
                               bolspaceMapper,
                               dalspaceMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5345c624c670617dc39d0cc67c5dc932</Hash>
</Codenesium>*/
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
        public class StudioService: AbstractStudioService, IStudioService
        {
                public StudioService(
                        ILogger<StudioRepository> logger,
                        IStudioRepository studioRepository,
                        IApiStudioRequestModelValidator studioModelValidator,
                        IBOLStudioMapper bolstudioMapper,
                        IDALStudioMapper dalstudioMapper)
                        : base(logger,
                               studioRepository,
                               studioModelValidator,
                               bolstudioMapper,
                               dalstudioMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5354f8551e2c23e32b07a34e62ccea85</Hash>
</Codenesium>*/
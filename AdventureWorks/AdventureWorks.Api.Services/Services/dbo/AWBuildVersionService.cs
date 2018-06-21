using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class AWBuildVersionService : AbstractAWBuildVersionService, IAWBuildVersionService
        {
                public AWBuildVersionService(
                        ILogger<IAWBuildVersionRepository> logger,
                        IAWBuildVersionRepository aWBuildVersionRepository,
                        IApiAWBuildVersionRequestModelValidator aWBuildVersionModelValidator,
                        IBOLAWBuildVersionMapper bolaWBuildVersionMapper,
                        IDALAWBuildVersionMapper dalaWBuildVersionMapper
                        )
                        : base(logger,
                               aWBuildVersionRepository,
                               aWBuildVersionModelValidator,
                               bolaWBuildVersionMapper,
                               dalaWBuildVersionMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f81c9e69e8cdb3dc3a232881dc80fae1</Hash>
</Codenesium>*/
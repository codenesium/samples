using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class AWBuildVersionService: AbstractAWBuildVersionService, IAWBuildVersionService
        {
                public AWBuildVersionService(
                        ILogger<AWBuildVersionRepository> logger,
                        IAWBuildVersionRepository aWBuildVersionRepository,
                        IApiAWBuildVersionRequestModelValidator aWBuildVersionModelValidator,
                        IBOLAWBuildVersionMapper bolaWBuildVersionMapper,
                        IDALAWBuildVersionMapper dalaWBuildVersionMapper)
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
    <Hash>64d499c3612c765518aba8632c29e54b</Hash>
</Codenesium>*/
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
                               dalaWBuildVersionMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>919f88eded8f12a26321681ec39b7129</Hash>
</Codenesium>*/
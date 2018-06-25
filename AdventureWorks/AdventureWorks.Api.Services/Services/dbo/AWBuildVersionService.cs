using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public partial class AWBuildVersionService : AbstractAWBuildVersionService, IAWBuildVersionService
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
    <Hash>6c1ec3c744dbeebddb6ca92692297079</Hash>
</Codenesium>*/
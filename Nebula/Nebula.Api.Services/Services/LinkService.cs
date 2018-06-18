using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class LinkService: AbstractLinkService, ILinkService
        {
                public LinkService(
                        ILogger<ILinkRepository> logger,
                        ILinkRepository linkRepository,
                        IApiLinkRequestModelValidator linkModelValidator,
                        IBOLLinkMapper bollinkMapper,
                        IDALLinkMapper dallinkMapper
                        ,
                        IBOLLinkLogMapper bolLinkLogMapper,
                        IDALLinkLogMapper dalLinkLogMapper

                        )
                        : base(logger,
                               linkRepository,
                               linkModelValidator,
                               bollinkMapper,
                               dallinkMapper
                               ,
                               bolLinkLogMapper,
                               dalLinkLogMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>e48f172d41ec2733d3e90d8b59582ad8</Hash>
</Codenesium>*/
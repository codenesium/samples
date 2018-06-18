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
        public class LinkLogService: AbstractLinkLogService, ILinkLogService
        {
                public LinkLogService(
                        ILogger<ILinkLogRepository> logger,
                        ILinkLogRepository linkLogRepository,
                        IApiLinkLogRequestModelValidator linkLogModelValidator,
                        IBOLLinkLogMapper bollinkLogMapper,
                        IDALLinkLogMapper dallinkLogMapper

                        )
                        : base(logger,
                               linkLogRepository,
                               linkLogModelValidator,
                               bollinkLogMapper,
                               dallinkLogMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>e4fc87009f8e163868d4766e03ef837d</Hash>
</Codenesium>*/
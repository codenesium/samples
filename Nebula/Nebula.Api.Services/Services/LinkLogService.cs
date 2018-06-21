using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
        public class LinkLogService : AbstractLinkLogService, ILinkLogService
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
                               dallinkLogMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>c23cd262769a9285b29b001c908141d4</Hash>
</Codenesium>*/
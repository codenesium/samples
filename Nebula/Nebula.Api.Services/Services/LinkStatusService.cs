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
        public class LinkStatusService : AbstractLinkStatusService, ILinkStatusService
        {
                public LinkStatusService(
                        ILogger<ILinkStatusRepository> logger,
                        ILinkStatusRepository linkStatusRepository,
                        IApiLinkStatusRequestModelValidator linkStatusModelValidator,
                        IBOLLinkStatusMapper bollinkStatusMapper,
                        IDALLinkStatusMapper dallinkStatusMapper,
                        IBOLLinkMapper bolLinkMapper,
                        IDALLinkMapper dalLinkMapper
                        )
                        : base(logger,
                               linkStatusRepository,
                               linkStatusModelValidator,
                               bollinkStatusMapper,
                               dallinkStatusMapper,
                               bolLinkMapper,
                               dalLinkMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e5ab78d5fe4aba39d7eb55a9bf13f83c</Hash>
</Codenesium>*/
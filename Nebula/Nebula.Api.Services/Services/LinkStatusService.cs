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
        public class LinkStatusService: AbstractLinkStatusService, ILinkStatusService
        {
                public LinkStatusService(
                        ILogger<LinkStatusRepository> logger,
                        ILinkStatusRepository linkStatusRepository,
                        IApiLinkStatusRequestModelValidator linkStatusModelValidator,
                        IBOLLinkStatusMapper bollinkStatusMapper,
                        IDALLinkStatusMapper dallinkStatusMapper)
                        : base(logger,
                               linkStatusRepository,
                               linkStatusModelValidator,
                               bollinkStatusMapper,
                               dallinkStatusMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8efbfbbc94870b10ab8679bfbd58efcc</Hash>
</Codenesium>*/
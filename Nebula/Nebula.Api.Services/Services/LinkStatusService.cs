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
                        IDALLinkStatusMapper dallinkStatusMapper
                        ,
                        IBOLLinkMapper bolLinkMapper,
                        IDALLinkMapper dalLinkMapper

                        )
                        : base(logger,
                               linkStatusRepository,
                               linkStatusModelValidator,
                               bollinkStatusMapper,
                               dallinkStatusMapper
                               ,
                               bolLinkMapper,
                               dalLinkMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>301c86b2f4777caede4011a861127509</Hash>
</Codenesium>*/
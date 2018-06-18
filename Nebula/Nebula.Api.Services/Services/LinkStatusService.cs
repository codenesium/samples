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
                        ILogger<ILinkStatusRepository> logger,
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
    <Hash>56a629cb584df169d72ea9b6f02d7a4a</Hash>
</Codenesium>*/
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
                        ILogger<LinkRepository> logger,
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
    <Hash>9f85e4d896d4413eb041513be404330b</Hash>
</Codenesium>*/
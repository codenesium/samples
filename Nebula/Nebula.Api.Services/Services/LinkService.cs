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
                        IDALLinkMapper dallinkMapper)
                        : base(logger,
                               linkRepository,
                               linkModelValidator,
                               bollinkMapper,
                               dallinkMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>0f81e4a3ab14963c802172e2db1ed506</Hash>
</Codenesium>*/
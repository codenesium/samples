using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class LinkRepository: AbstractLinkRepository, ILinkRepository
        {
                public LinkRepository(
                        ILogger<LinkRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>fa6cabe967dffb4a2e10520b8586d910</Hash>
</Codenesium>*/
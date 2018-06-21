using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class LinkRepository : AbstractLinkRepository, ILinkRepository
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
    <Hash>28425dd51c15c1f85299484812080823</Hash>
</Codenesium>*/
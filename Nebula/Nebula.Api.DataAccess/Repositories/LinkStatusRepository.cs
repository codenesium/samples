using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class LinkStatusRepository : AbstractLinkStatusRepository, ILinkStatusRepository
        {
                public LinkStatusRepository(
                        ILogger<LinkStatusRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>1f890a63d262ad8164abb76d126a3894</Hash>
</Codenesium>*/
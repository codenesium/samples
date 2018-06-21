using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class LinkLogRepository : AbstractLinkLogRepository, ILinkLogRepository
        {
                public LinkLogRepository(
                        ILogger<LinkLogRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8135c2dc71e4c41b5a6c9d564591d5e9</Hash>
</Codenesium>*/
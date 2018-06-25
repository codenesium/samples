using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class BadgesRepository : AbstractBadgesRepository, IBadgesRepository
        {
                public BadgesRepository(
                        ILogger<BadgesRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>134c8c6e79ffd6859fb78a114f3046cd</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public class BadgesRepository : AbstractBadgesRepository, IBadgesRepository
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
    <Hash>32097d4d5d2c63b574644b818f5c94a4</Hash>
</Codenesium>*/
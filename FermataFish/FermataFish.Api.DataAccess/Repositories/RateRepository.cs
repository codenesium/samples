using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class RateRepository : AbstractRateRepository, IRateRepository
        {
                public RateRepository(
                        ILogger<RateRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a47cdbca38ba3b6816bbe51c6fa3980a</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public partial class RateRepository : AbstractRateRepository, IRateRepository
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
    <Hash>1f03a5b09c7096f6be8a3dafa66f7139</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SpecialOfferRepository : AbstractSpecialOfferRepository, ISpecialOfferRepository
        {
                public SpecialOfferRepository(
                        ILogger<SpecialOfferRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2e2d0960c4b89ea061233d506e6fe41f</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SpecialOfferRepository: AbstractSpecialOfferRepository, ISpecialOfferRepository
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
    <Hash>48cfc621f0e38e5026b58cc397d8c6fe</Hash>
</Codenesium>*/
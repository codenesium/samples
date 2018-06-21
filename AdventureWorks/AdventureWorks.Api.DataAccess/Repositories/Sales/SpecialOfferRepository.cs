using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>0d33743f5f77b8b6f27424e56c343391</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class SpecialOfferRepository : AbstractSpecialOfferRepository, ISpecialOfferRepository
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
    <Hash>5210abad2f7ecb39851fd068e71ab687</Hash>
</Codenesium>*/
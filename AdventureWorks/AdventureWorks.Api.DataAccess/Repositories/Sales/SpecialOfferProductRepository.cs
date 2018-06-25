using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class SpecialOfferProductRepository : AbstractSpecialOfferProductRepository, ISpecialOfferProductRepository
        {
                public SpecialOfferProductRepository(
                        ILogger<SpecialOfferProductRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>c050ce12693c445694922102c7c0ebd1</Hash>
</Codenesium>*/
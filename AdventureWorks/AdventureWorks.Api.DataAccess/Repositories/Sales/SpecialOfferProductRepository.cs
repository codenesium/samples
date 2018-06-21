using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SpecialOfferProductRepository : AbstractSpecialOfferProductRepository, ISpecialOfferProductRepository
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
    <Hash>f51869fbf8ae0d8961989757223e3d31</Hash>
</Codenesium>*/
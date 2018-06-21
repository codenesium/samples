using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductVendorRepository : AbstractProductVendorRepository, IProductVendorRepository
        {
                public ProductVendorRepository(
                        ILogger<ProductVendorRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d94726b360e1d9fe9923334e399db3f6</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
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
    <Hash>bd203af9d8d0d31f88b3c73dfdde69c5</Hash>
</Codenesium>*/
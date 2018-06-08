using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductVendorRepository: AbstractProductVendorRepository, IProductVendorRepository
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
    <Hash>363e915fcd3edc654ed8bac41e2c2562</Hash>
</Codenesium>*/
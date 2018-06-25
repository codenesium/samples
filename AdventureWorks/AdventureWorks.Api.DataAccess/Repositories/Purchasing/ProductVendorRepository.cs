using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ProductVendorRepository : AbstractProductVendorRepository, IProductVendorRepository
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
    <Hash>71822db8d75f5b96a34759435a1c8dbf</Hash>
</Codenesium>*/
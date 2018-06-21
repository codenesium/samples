using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductModelRepository : AbstractProductModelRepository, IProductModelRepository
        {
                public ProductModelRepository(
                        ILogger<ProductModelRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a4bfb59497b1f4547408d1b35652ae4a</Hash>
</Codenesium>*/
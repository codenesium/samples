using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>125aea03f45b1c85a8a9c1092fc40642</Hash>
</Codenesium>*/
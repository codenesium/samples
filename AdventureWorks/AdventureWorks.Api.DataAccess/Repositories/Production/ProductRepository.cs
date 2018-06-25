using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ProductRepository : AbstractProductRepository, IProductRepository
        {
                public ProductRepository(
                        ILogger<ProductRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>97a3e9d421d874bc337ce1a3e8f1a20f</Hash>
</Codenesium>*/
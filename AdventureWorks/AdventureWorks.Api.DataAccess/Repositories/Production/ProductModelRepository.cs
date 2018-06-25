using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ProductModelRepository : AbstractProductModelRepository, IProductModelRepository
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
    <Hash>23aedcd74dfc48ccc86814b95acacea8</Hash>
</Codenesium>*/
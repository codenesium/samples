using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ProductModelProductDescriptionCultureRepository : AbstractProductModelProductDescriptionCultureRepository, IProductModelProductDescriptionCultureRepository
        {
                public ProductModelProductDescriptionCultureRepository(
                        ILogger<ProductModelProductDescriptionCultureRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>50005e6d361a2527baf2b80210f634d6</Hash>
</Codenesium>*/
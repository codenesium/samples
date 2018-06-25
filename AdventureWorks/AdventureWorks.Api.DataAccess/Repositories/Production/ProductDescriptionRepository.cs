using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ProductDescriptionRepository : AbstractProductDescriptionRepository, IProductDescriptionRepository
        {
                public ProductDescriptionRepository(
                        ILogger<ProductDescriptionRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>1d3d22021e3bbfb8bf0d7d19a56584a7</Hash>
</Codenesium>*/
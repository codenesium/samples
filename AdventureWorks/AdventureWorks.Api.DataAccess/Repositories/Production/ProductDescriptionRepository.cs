using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductDescriptionRepository : AbstractProductDescriptionRepository, IProductDescriptionRepository
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
    <Hash>e4d8d75f0c95a18b4e1bc7d5ae8ddeb4</Hash>
</Codenesium>*/
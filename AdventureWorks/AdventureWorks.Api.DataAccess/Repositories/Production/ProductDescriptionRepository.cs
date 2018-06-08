using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductDescriptionRepository: AbstractProductDescriptionRepository, IProductDescriptionRepository
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
    <Hash>9d5a051824f793b68a083c73ee7f3ef5</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
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
    <Hash>d627be12b9041954e138bc79c34e9b12</Hash>
</Codenesium>*/
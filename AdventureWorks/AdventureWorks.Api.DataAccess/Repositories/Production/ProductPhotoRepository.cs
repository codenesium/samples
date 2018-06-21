using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductPhotoRepository : AbstractProductPhotoRepository, IProductPhotoRepository
        {
                public ProductPhotoRepository(
                        ILogger<ProductPhotoRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>1b7c2254efd30053c6d1878d1371b4b0</Hash>
</Codenesium>*/
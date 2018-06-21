using Codenesium.DataConversionExtensions;
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
    <Hash>6adc689718110a06e2107032cec95da5</Hash>
</Codenesium>*/
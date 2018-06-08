using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductPhotoRepository: AbstractProductPhotoRepository, IProductPhotoRepository
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
    <Hash>401e4dbef40675123751017496041850</Hash>
</Codenesium>*/
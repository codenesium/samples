using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ProductPhotoRepository : AbstractProductPhotoRepository, IProductPhotoRepository
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
    <Hash>4ee6f24e04edf7ee4c06daa4d183269e</Hash>
</Codenesium>*/
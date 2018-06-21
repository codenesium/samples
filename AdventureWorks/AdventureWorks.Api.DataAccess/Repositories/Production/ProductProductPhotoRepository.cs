using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductProductPhotoRepository : AbstractProductProductPhotoRepository, IProductProductPhotoRepository
        {
                public ProductProductPhotoRepository(
                        ILogger<ProductProductPhotoRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>c38cd641863d50a1fb8e9c69158e8825</Hash>
</Codenesium>*/
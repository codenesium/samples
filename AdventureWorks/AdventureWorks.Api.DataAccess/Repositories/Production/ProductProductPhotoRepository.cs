using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>198b1a3445646ad16151cbc733df3d18</Hash>
</Codenesium>*/
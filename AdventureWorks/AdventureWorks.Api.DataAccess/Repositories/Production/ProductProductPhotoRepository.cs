using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ProductProductPhotoRepository : AbstractProductProductPhotoRepository, IProductProductPhotoRepository
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
    <Hash>5b677c62baccc1706702077d7f0fae85</Hash>
</Codenesium>*/
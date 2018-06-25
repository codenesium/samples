using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ProductModelIllustrationRepository : AbstractProductModelIllustrationRepository, IProductModelIllustrationRepository
        {
                public ProductModelIllustrationRepository(
                        ILogger<ProductModelIllustrationRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f80050018e6331f8343f9a2ce48cba60</Hash>
</Codenesium>*/
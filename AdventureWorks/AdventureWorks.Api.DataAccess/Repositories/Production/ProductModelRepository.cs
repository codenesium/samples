using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductModelRepository: AbstractProductModelRepository, IProductModelRepository
        {
                public ProductModelRepository(
                        ILogger<ProductModelRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7b44e3725734dc909732eff02fb11e5e</Hash>
</Codenesium>*/
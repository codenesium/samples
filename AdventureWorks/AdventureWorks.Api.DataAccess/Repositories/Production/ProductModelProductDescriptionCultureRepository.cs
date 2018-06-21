using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductModelProductDescriptionCultureRepository : AbstractProductModelProductDescriptionCultureRepository, IProductModelProductDescriptionCultureRepository
        {
                public ProductModelProductDescriptionCultureRepository(
                        ILogger<ProductModelProductDescriptionCultureRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ddaa79168eb6d20f2852b94cd19b575d</Hash>
</Codenesium>*/
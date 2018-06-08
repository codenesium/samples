using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
        public class SaleRepository: AbstractSaleRepository, ISaleRepository
        {
                public SaleRepository(
                        ILogger<SaleRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>48aca7ed004571c43ac6ca6773835b94</Hash>
</Codenesium>*/
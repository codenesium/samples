using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
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
    <Hash>4d07251713d89b271127c986b01b01dd</Hash>
</Codenesium>*/
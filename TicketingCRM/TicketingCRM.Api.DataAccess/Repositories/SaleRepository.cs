using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
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
    <Hash>f2f8330c4e1ec3f1da43a6ede240d041</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class SaleRepository : AbstractSaleRepository, ISaleRepository
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
    <Hash>10b38fddb2472331b238e6f3a7328c93</Hash>
</Codenesium>*/
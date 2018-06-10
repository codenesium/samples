using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class SaleTicketsService: AbstractSaleTicketsService, ISaleTicketsService
        {
                public SaleTicketsService(
                        ILogger<SaleTicketsRepository> logger,
                        ISaleTicketsRepository saleTicketsRepository,
                        IApiSaleTicketsRequestModelValidator saleTicketsModelValidator,
                        IBOLSaleTicketsMapper bolsaleTicketsMapper,
                        IDALSaleTicketsMapper dalsaleTicketsMapper)
                        : base(logger,
                               saleTicketsRepository,
                               saleTicketsModelValidator,
                               bolsaleTicketsMapper,
                               dalsaleTicketsMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>fcf826e408e1b8336fef048a91baf846</Hash>
</Codenesium>*/
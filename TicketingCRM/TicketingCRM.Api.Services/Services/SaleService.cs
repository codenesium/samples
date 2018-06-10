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
        public class SaleService: AbstractSaleService, ISaleService
        {
                public SaleService(
                        ILogger<SaleRepository> logger,
                        ISaleRepository saleRepository,
                        IApiSaleRequestModelValidator saleModelValidator,
                        IBOLSaleMapper bolsaleMapper,
                        IDALSaleMapper dalsaleMapper)
                        : base(logger,
                               saleRepository,
                               saleModelValidator,
                               bolsaleMapper,
                               dalsaleMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>533dd15c635609d9f5099a32c09c3f2d</Hash>
</Codenesium>*/
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
                        IDALSaleTicketsMapper dalsaleTicketsMapper

                        )
                        : base(logger,
                               saleTicketsRepository,
                               saleTicketsModelValidator,
                               bolsaleTicketsMapper,
                               dalsaleTicketsMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>b2a63c89061d7842f40cd433686f447f</Hash>
</Codenesium>*/
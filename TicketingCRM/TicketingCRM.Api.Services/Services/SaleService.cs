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
                        IDALSaleMapper dalsaleMapper
                        ,
                        IBOLSaleTicketsMapper bolSaleTicketsMapper,
                        IDALSaleTicketsMapper dalSaleTicketsMapper

                        )
                        : base(logger,
                               saleRepository,
                               saleModelValidator,
                               bolsaleMapper,
                               dalsaleMapper
                               ,
                               bolSaleTicketsMapper,
                               dalSaleTicketsMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>a6229fdf88b99c9af3a38292d3aec49b</Hash>
</Codenesium>*/
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
                        ILogger<ISaleRepository> logger,
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
    <Hash>63638b823db863b75ebb570334e0e837</Hash>
</Codenesium>*/
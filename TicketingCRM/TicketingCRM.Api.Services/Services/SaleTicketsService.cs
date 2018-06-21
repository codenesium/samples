using Codenesium.DataConversionExtensions;
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
        public class SaleTicketsService : AbstractSaleTicketsService, ISaleTicketsService
        {
                public SaleTicketsService(
                        ILogger<ISaleTicketsRepository> logger,
                        ISaleTicketsRepository saleTicketsRepository,
                        IApiSaleTicketsRequestModelValidator saleTicketsModelValidator,
                        IBOLSaleTicketsMapper bolsaleTicketsMapper,
                        IDALSaleTicketsMapper dalsaleTicketsMapper
                        )
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
    <Hash>fb6ba91e94c2eb14e9fbce4c60caa280</Hash>
</Codenesium>*/
using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;

namespace PetStoreNS.Api.Web
{
        [Route("api/sales")]
        [ApiVersion("1.0")]
        public class SaleController: AbstractSaleController
        {
                public SaleController(
                        ApiSettings settings,
                        ILogger<SaleController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISaleService saleService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               saleService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f4cdabc8d6ffa3bc8f3d3440e78d1538</Hash>
</Codenesium>*/
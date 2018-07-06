using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/salesOrderHeaderSalesReasons")]
        [ApiController]
        [ApiVersion("1.0")]
        public class SalesOrderHeaderSalesReasonController : AbstractSalesOrderHeaderSalesReasonController
        {
                public SalesOrderHeaderSalesReasonController(
                        ApiSettings settings,
                        ILogger<SalesOrderHeaderSalesReasonController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesOrderHeaderSalesReasonService salesOrderHeaderSalesReasonService,
                        IApiSalesOrderHeaderSalesReasonModelMapper salesOrderHeaderSalesReasonModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesOrderHeaderSalesReasonService,
                               salesOrderHeaderSalesReasonModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>bf51db6c9154c075cb531df6ab903d85</Hash>
</Codenesium>*/
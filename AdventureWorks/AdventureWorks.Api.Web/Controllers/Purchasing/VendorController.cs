using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/vendors")]
        [ApiVersion("1.0")]
        public class VendorController: AbstractVendorController
        {
                public VendorController(
                        ApiSettings settings,
                        ILogger<VendorController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IVendorService vendorService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               vendorService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>b38555561f24f64ae8f2af45f01d1e9e</Hash>
</Codenesium>*/
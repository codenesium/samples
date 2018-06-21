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
        [Route("api/vendors")]
        [ApiVersion("1.0")]
        public class VendorController : AbstractVendorController
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
    <Hash>497e27635b38aa5e25de694d7ea52c3e</Hash>
</Codenesium>*/
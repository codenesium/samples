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
        [Route("api/businessEntityAddresses")]
        [ApiVersion("1.0")]
        public class BusinessEntityAddressController : AbstractBusinessEntityAddressController
        {
                public BusinessEntityAddressController(
                        ApiSettings settings,
                        ILogger<BusinessEntityAddressController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBusinessEntityAddressService businessEntityAddressService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               businessEntityAddressService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>e1d4f75bcd54f6a7da9bb22a85e650f7</Hash>
</Codenesium>*/
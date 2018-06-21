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
        [Route("api/addresses")]
        [ApiVersion("1.0")]
        public class AddressController : AbstractAddressController
        {
                public AddressController(
                        ApiSettings settings,
                        ILogger<AddressController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IAddressService addressService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               addressService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ef4d77269d613fe1624fe9bb4bee255f</Hash>
</Codenesium>*/
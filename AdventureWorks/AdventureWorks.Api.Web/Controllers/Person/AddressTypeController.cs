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
        [Route("api/addressTypes")]
        [ApiVersion("1.0")]
        public class AddressTypeController : AbstractAddressTypeController
        {
                public AddressTypeController(
                        ApiSettings settings,
                        ILogger<AddressTypeController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IAddressTypeService addressTypeService,
                        IApiAddressTypeModelMapper addressTypeModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               addressTypeService,
                               addressTypeModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>4b33829feba78f2f93d2afc4aecce1d9</Hash>
</Codenesium>*/
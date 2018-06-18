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
        [Route("api/contactTypes")]
        [ApiVersion("1.0")]
        public class ContactTypeController: AbstractContactTypeController
        {
                public ContactTypeController(
                        ApiSettings settings,
                        ILogger<ContactTypeController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IContactTypeService contactTypeService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               contactTypeService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>8dbeca98978282a2c2e2adaf078e94ec</Hash>
</Codenesium>*/
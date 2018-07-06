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
        [Route("api/businessEntityContacts")]
        [ApiController]
        [ApiVersion("1.0")]
        public class BusinessEntityContactController : AbstractBusinessEntityContactController
        {
                public BusinessEntityContactController(
                        ApiSettings settings,
                        ILogger<BusinessEntityContactController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBusinessEntityContactService businessEntityContactService,
                        IApiBusinessEntityContactModelMapper businessEntityContactModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               businessEntityContactService,
                               businessEntityContactModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>03d0b9b6f34cf69915f4928c1540a930</Hash>
</Codenesium>*/
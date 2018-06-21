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
        [ApiVersion("1.0")]
        public class BusinessEntityContactController : AbstractBusinessEntityContactController
        {
                public BusinessEntityContactController(
                        ApiSettings settings,
                        ILogger<BusinessEntityContactController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBusinessEntityContactService businessEntityContactService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               businessEntityContactService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>8ee1e142a5d903e3c6d61740cbe1a424</Hash>
</Codenesium>*/